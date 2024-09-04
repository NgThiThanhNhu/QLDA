using System.ComponentModel.DataAnnotations;

namespace Model.HETHONG.TAIKHOAN.Reuquest
{
    public class LoginRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên đăng nhập không được để trống")]
        public string? UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được để trống")]
        public string? Password { get; set; } 

    }
}
