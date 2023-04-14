using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TChiTietSp
{
    public string MaChiTietSp { get; set; } = null!;

    public string? MaSp { get; set; }

    public string? MaMauSac { get; set; }

    public string? MaKichCo { get; set; }

    public int? SoLuong { get; set; }

    public string? AnhDaiDien { get; set; }

    public virtual TKichCo? MaKichCoNavigation { get; set; }

    public virtual TMauSac? MaMauSacNavigation { get; set; }

    public virtual TSanPham? MaSpNavigation { get; set; }

    public virtual ICollection<TChiTietHdb> TChiTietHdbs { get; } = new List<TChiTietHdb>();
}
