using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HETHONG.TAIKHOAN.Reuquest
{
    public class GetPhanQuyenRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserId không được để trống")]
        public Guid? UserId { get; set; }
    }
}
