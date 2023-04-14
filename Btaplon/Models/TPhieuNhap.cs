using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TPhieuNhap
{
    public string SoHdn { get; set; } = null!;

    public DateTime? NgayNhap { get; set; }

    public string? MaNcc { get; set; }

    public virtual TNhaCungCap? MaNccNavigation { get; set; }
}
