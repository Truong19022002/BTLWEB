using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TLoaiSp
{
    public string MaLoai { get; set; } = null!;

    public string? Loai { get; set; }

    public virtual ICollection<TSanPham> TSanPhams { get; } = new List<TSanPham>();
}
