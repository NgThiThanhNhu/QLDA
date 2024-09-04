using System;
using System.Collections.Generic;

namespace Entity.DBContent;

public partial class SYS_MENU
{
    public string ControllerName { get; set; } = null!;

    public string Controller { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string TenGoi { get; set; } = null!;

    public Guid NhomQuyenId { get; set; }

    public int? Sort { get; set; }

    public bool CoXem { get; set; }

    public bool CoThem { get; set; }

    public bool CoCapNhat { get; set; }

    public bool CoXoa { get; set; }

    public bool CoDuyet { get; set; }

    public bool CoThongKe { get; set; }

    public bool IsActived { get; set; }

    public bool IsShowMenu { get; set; }
}
