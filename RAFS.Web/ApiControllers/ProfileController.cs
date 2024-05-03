using AutoMapper;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RAFS.Core.Models;
using RAFS.Core.Repositories.Generics;
using RAFS.Core.Services.IService;
using RAFS.Core.Services.Service;
using RAFS.Web.Models;
using RAFS.Web.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RAFS.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<AspUser> _userManager;
        private readonly IMapper _mapper;
        private readonly DriveAPIController _drive;
        private readonly CustomIdentityErrorDescriber _customError;
        private readonly IUnitOfWork _uow;
        public ProfileController(ILogger<AuthenticationController> logger,
                                UserManager<AspUser> userManager,
                                IMapper mapper,
                                DriveAPIController drive,  
                                CustomIdentityErrorDescriber customError,
                                IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _drive = drive;
            _customError = customError;
            _uow = unitOfWork;
        }


        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.userId);
            if (user != null)
            {
                //Check if Email is null
                //If not, change password using Identity framework
                if (!user.Email.IsNullOrEmpty())
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.currentPassword, model.newPassword);
                    if (result.Errors.Any())
                    {
                        return BadRequest(result);
                    }
                    return Ok();
                }
                else
                {
                    //Get password validators to check password
                    var validators = _userManager.PasswordValidators;
                    var oldPasswordCheck = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.currentPassword);
                    var identityErrors = new List<IdentityError>();
                    //Compare user input with hashed passsword
                    //If fialed, return PasswordMismatch error
                    if (oldPasswordCheck == PasswordVerificationResult.Failed)
                    {
                        var error = _customError.PasswordMismatch();
                        var identityError = new IdentityError { Code = error.Code, Description = error.Description };
                        identityErrors.Add(identityError);
                    }

                    //Check new password against password validators.
                    foreach (var validator in validators)
                    {
                        var result = await validator.ValidateAsync(_userManager, user, model.newPassword);

                        foreach (var error in result.Errors)
                        {
                            identityErrors.Add(error);
                        }
                    }

                    // If there are any errors, return them as BadRequest
                    if (identityErrors.Any())
                    {
                        var identityResult = IdentityResult.Failed(identityErrors.ToArray());
                        return BadRequest(identityResult);
                    }

                    //Hash the password and update the user;
                    string hashedPassword = _userManager.PasswordHasher.HashPassword(user, model.newPassword);
                    user.PasswordHash = hashedPassword;
                    await _uow.aspUserRepo.UpdateAsync(user);
                    await _uow.SaveAsync();

                    // Password changed successfully
                    return Ok();
                }

            }

            return BadRequest();
        }

        [HttpPost("UpdateInfo")]
        public async Task<IActionResult> UpdateInfo([FromBody] UpdateInfoModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.FullName = model.FullName;
                user.Address = model.Address;
                user.Description = model.Description;
                user.LastUpdated = DateTime.UtcNow;
                var result = await _userManager.UpdateAsync(user);

                if (result.Errors.Any())
                {
                    return BadRequest(result);
                }
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("UpdateTechnicianInfo")]
        public async Task<IActionResult> UpdateTechnicianInfo([FromBody] UpdateTechnicianInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.FullName = model.FullName;
                user.Address = model.Address;
                user.Description = model.Description;
                user.LastUpdated = DateTime.UtcNow;

                //Update the user
                await _uow.aspUserRepo.UpdateAsync(user);
                await _uow.SaveAsync();

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("UpdateAvatar")]
        public async Task<IActionResult> UpdateAvatar(ChangeAvatarModel data)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(data.UserId);
                if (user != null)
                {
                    string serverPath = Path.GetTempFileName();
                    using (var stream = new FileStream(serverPath, FileMode.Create))
                    {
                        data.Avatar.CopyTo(stream);
                    }
                    string logoLink = user.Avatar;

                    string saveLogoLink = await _drive.CreateDriveFile(serverPath);
                    user.Avatar = saveLogoLink;
                    var res = await _userManager.UpdateAsync(user);
                    if (res == null)
                    {
                        return BadRequest("Cannot upload logo!");
                    }
                    //bool result = await _drive.UpdateDriveFile(logoLink, serverPath);
                    return Ok();
                }
                return BadRequest();


            }
            catch (Exception ex)
            {
                return BadRequest("Message: " + ex);
            }
        }

        [HttpGet("GetAvatar")]
        public async Task<IActionResult> GetAvatar()
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    var avatar = user.Avatar;
                    return Ok(avatar);
                }
                return BadRequest("User not found!");


            }
            catch (Exception ex)
            {
                return BadRequest("Message: " + ex);
            }
        }

        [HttpPost("AddPassword")]
        public async Task<IActionResult> AddPassword(AddPasswordModel addPassword)
        {
            AspUser user = await _userManager.FindByIdAsync(addPassword.UserId);
            if (user == null)
            {
                return BadRequest();
            }

            var result = await _userManager.AddPasswordAsync(user, addPassword.newPassword);
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}
