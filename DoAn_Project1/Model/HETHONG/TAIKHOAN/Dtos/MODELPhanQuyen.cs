using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;

namespace Model.HETHONG.TAIKHOAN.Dtos
{
    public class MODELPhanQuyen 
    {
        public string ControllerName { get; set; }
        public bool IsXem { get; set; }
        public bool IsThem { get; set; }
        public bool IsCapNhat { get; set; }
        public bool IsXoa { get; set; }
        public bool IsDuyet { get; set; }
        public bool IsThongKe { get; set; }
    }
}
