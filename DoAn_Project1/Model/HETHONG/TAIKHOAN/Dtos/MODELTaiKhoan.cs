using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;

namespace Model.HETHONG.TAIKHOAN.Dtos
{
    public class MODELTaiKhoan : MODELBase
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; } = null!;
        public string VaiTro { get; set; }
        public Guid? VaiTroId { get; set; }
        public string Tinh { get; set; }
        public Guid? TinhId { get; set; }
        public string Huyen { get; set; }
        public Guid? HuyenId { get; set; }
        public string Xa { get; set; }
        public Guid? XaId { get; set; }
        public Guid? DonViId { get; set; }
        public string DonVi { get; set; }
        public Guid? PhongBanId { get; set; }
        public string? PhongBan { get; set; }
        public string? SoDienThoai { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? HoLot { get; set; } = null!;
        public string? Ten { get; set; } = null!;
        public DateTime NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public int? BoCucGiaoDien { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? Guid { get; set; } = null!; // ĐÂY LÀ PASS ĐÃ MÃ HÓA
        public string Token { get; set; }
    }
}
