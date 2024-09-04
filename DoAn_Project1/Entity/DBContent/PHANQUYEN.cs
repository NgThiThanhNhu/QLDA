using System;
using System.Collections.Generic;

namespace Entity.DBContent;

public partial class PHANQUYEN
{
    public Guid Id { get; set; }

    public Guid VaiTroId { get; set; }

    public string ControllerName { get; set; } = null!;

    public bool IsXem { get; set; }

    public bool IsCapNhat { get; set; }

    public bool IsXoa { get; set; }

    public bool IsDuyet { get; set; }

    public bool IsThongKe { get; set; }
}
