using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TChatlieuSp
{
    public string MaCl { get; set; } = null!;

    public string? TenCl { get; set; }

    public virtual ICollection<TSanPham> TSanPhams { get; } = new List<TSanPham>();
}
