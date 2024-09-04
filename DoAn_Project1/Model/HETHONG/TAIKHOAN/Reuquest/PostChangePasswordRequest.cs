using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HETHONG.TAIKHOAN.Reuquest
{
    public class PostChangePasswordRequest
    {
        public Guid? Id { get; set; }
        public string? MatKhauCu { get; set; }
        public string? MatKhauMoi { get; set; }
        public string? XacNhanMatKhauMoi { get; set; }
    }
}
