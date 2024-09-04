using System;
using System.Collections.Generic;

namespace Entity.DBContent;

public partial class TAIKHOAN
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public Guid? TinhId { get; set; }

    public Guid? HuyenId { get; set; }

    public Guid? XaId { get; set; }

    public Guid VaiTroId { get; set; }

    public Guid? DonViId { get; set; }

    public Guid? PhongBanId { get; set; }

    public Guid? NguoiQuanLyId { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? HoLot { get; set; }

    public string Ten { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public int GioiTinh { get; set; }

    public string? AnhDaiDien { get; set; }

    public string MatKhau { get; set; } = null!;

    public string MatKhauSalt { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
}
