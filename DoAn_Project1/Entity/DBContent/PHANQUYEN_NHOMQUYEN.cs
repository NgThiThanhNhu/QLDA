using System;
using System.Collections.Generic;

namespace Entity.DBContent;

public partial class PHANQUYEN_NHOMQUYEN
{
    public Guid Id { get; set; }

    public string TenGoi { get; set; } = null!;

    public int Sort { get; set; }

    public string? Icon { get; set; }

    public bool IsActived { get; set; }
}
