using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TNhaCungCap
{
    public string MaNcc { get; set; } = null!;

    public string? TenNcc { get; set; }

    public string? DiaChi { get; set; }

    public int? Sdt { get; set; }

    public virtual ICollection<TPhieuNhap> TPhieuNhaps { get; } = new List<TPhieuNhap>();

    public virtual ICollection<TSanPham> TSanPhams { get; } = new List<TSanPham>();
}
