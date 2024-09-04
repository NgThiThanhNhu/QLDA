using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HETHONG.VAITRO.Dtos
{
    public class MODELVaiTro_PhanQuyen
    {
        public Guid Id { get; set; }
        public Guid VaiTroId { get; set; }
        public string ControllerName { get; set; }
        public bool IsCapNhat { get; set; } = false;
        public bool IsDuyet { get; set; } = false;
        public bool IsThem { get; set; } = false;
        public bool IsThongKe { get; set; } = false;
        public bool IsXem { get; set; } = false;
        public bool IsXoa { get; set; } = false;
        public string? TenGoi { get; set; }
        public bool CoCapNhat { get; set; } = false;
        public bool CoDuyet { get; set; } = false;
        public bool CoThem { get; set; } = false;
        public bool CoThongKe { get; set; } = false;
        public bool CoXem { get; set; } = false;
        public bool CoXoa { get; set; } = false;
    }
}
