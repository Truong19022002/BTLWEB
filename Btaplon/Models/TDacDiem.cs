using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TDacDiem
{
    public string MaDd { get; set; } = null!;

    public string? TenDd { get; set; }

    public virtual ICollection<TSanPham> TSanPhams { get; } = new List<TSanPham>();
}
