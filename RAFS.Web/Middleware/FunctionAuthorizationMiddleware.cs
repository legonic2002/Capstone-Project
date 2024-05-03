using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RAFS.Core.Models;
using RAFS.Core.Repositories.Generics;
using RAFS.Core.Services.IService;
using System.Data;
using System.Threading.Tasks;

namespace RAFS.Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FunctionAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public FunctionAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //Middleware to check if Technician account have the authorization to use function in farm
        public async Task Invoke(HttpContext httpContext,
                                UserManager<AspUser> _userManager,
                                IFarmAdminService _farmAdminService,
                                IUnitOfWork _uow)
        {
            //Get the current logged in user
            AspUser user = await _userManager.GetUserAsync(httpContext.User);
            Boolean isTechnician = false;
            List<int> authorizedFunction = [];

            //If user is logged in
            if(user != null)
            {
                //Get user's role
                var roles = await _userManager.GetRolesAsync(user);

                foreach (var role in roles)
                {
                    //Check for Technician
                    if (role.Equals("Technician"))
                    {
                        isTechnician = true;
                        //Get farm
                        Farm farm = await _farmAdminService.GetFarmByUserId(user.Id);
                        //Get UserFunctionFarm
                        var uff = await _uow.uffRepo.GetTechUFFsByFarmId(user.Id, farm.Id);
                        //Get all authorized functionID of that account
                        authorizedFunction = uff.Select(uff => uff.FunctionId).ToList();
                    }
                }
            }

            if (isTechnician)
            {
                //If accessing FundDiary, check for authorization
                if (httpContext.Request.Path.Equals("/FundDiary"))
                {
                    //Check if functionID 3 for FundDiary is present in authorized fuctionID list
                    if (!authorizedFunction.Contains(3))
                    {
                        httpContext.Response.Redirect("/AccessDenied");
                        return;
                    }
                }

                if (httpContext.Request.Path.Equals("/plant"))
                {
                    //Check if functionID 2 for plant diary is present in authorized fuctionID list
                    if (!authorizedFunction.Contains(2))
                    {
                        httpContext.Response.Redirect("/AccessDenied");
                        return;
                    }
                }

                if (httpContext.Request.Path.Equals("/milestone"))
                {
                    //Check if functionID 5 for milestone is present in authorized fuctionID list
                    if (!authorizedFunction.Contains(5))
                    {
                        httpContext.Response.Redirect("/AccessDenied");
                        return;
                    }
                }

                if (httpContext.Request.Path.Equals("/Materials"))
                {
                    //Check if functionID 4 for Materials is present in authorized fuctionID list
                    if (!authorizedFunction.Contains(4))
                    {
                        httpContext.Response.Redirect("/AccessDenied");
                        return;
                    }
                }

                if (httpContext.Request.Path.Equals("/diary"))
                {
                    //Check if functionID 2 for plant diary is present in authorized fuctionID list
                    if (!authorizedFunction.Contains(2))
                    {
                        httpContext.Response.Redirect("/AccessDenied");
                        return;
                    }
                }

                if (httpContext.Request.Path.Equals("/materialhistory"))
                {
                    //Check if functionID 2 for plant diary is present in authorized fuctionID list
                    if (!authorizedFunction.Contains(2))
                    {
                        httpContext.Response.Redirect("/AccessDenied");
                        return;
                    }
                }
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FunctionAuthorizationMiddleware>();
        }
    }
}
