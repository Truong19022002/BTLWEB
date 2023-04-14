using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TChiTietHdb
{
    public string SoHdb { get; set; } = null!;

    public string MaChiTietSp { get; set; } = null!;

    public int? SoLuongBan { get; set; }

    public int? DonGiaBan { get; set; }

    public double? GiamGia { get; set; }

    public virtual TChiTietSp MaChiTietSpNavigation { get; set; } = null!;

    public virtual THoaDonBan SoHdbNavigation { get; set; } = null!;
}
