using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HETHONG.TAIKHOAN.Reuquest
{
    public class GetByUserNameRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName không được để trống")]
        public string? UserName { get; set; }
    }
}
