using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;

namespace Model.HETHONG.TAIKHOAN.Dtos
{
    public class MODELTaiKhoanPhanQuyen 
    {
        public MODELTaiKhoan TaiKhoan { get; set; }
        public List<MODELMenuLogin> Menu { get; set; }
        public List<MODELPhanQuyen> PhanQuyen { get; set; }
        public List<MODELNhomQuyenLogin> NhomQuyen { get; set; }
    }

    public class MODELMenuLogin
    {
        public string ControllerName { get; set; }
        public string Action { get; set; }
        public string TenGoi { get; set; }
        public Guid NhomQuyenId { get; set; }
        public int? Sort { get; set; }
    }

    public class MODELNhomQuyenLogin
    {
        public Guid Id { get; set; }
        public string TenGoi { get; set; }

        public int? Sort { get; set; }
        public string Icon { get; set; }
    }
}
