using RAFS.Web.Validation;
using System.ComponentModel.DataAnnotations;

namespace RAFS.Web.Models
{
    public class UpdateInfoModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ.")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [RegularExpression(@"^(0|\+84)(\s|\.)?((3[2-9])|(5[689])|(7[06-9])|(8[1-689])|(9[0-46-9]))(\d)(\s|\.)?(\d{3})(\s|\.)?(\d{3})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Họ và tên không được để trống.")]
        public string FullName { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
    }

    public class UpdateTechnicianInfoModel
    {
        public string UserId { get; set; }
        [AllowEmptyEmail(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(0|\+84)(\s|\.)?((3[2-9])|(5[689])|(7[06-9])|(8[1-689])|(9[0-46-9]))(\d)(\s|\.)?(\d{3})(\s|\.)?(\d{3})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
    }
}
