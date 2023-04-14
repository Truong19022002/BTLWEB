using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class THoaDonBan
{
    public string SoHdb { get; set; } = null!;

    public DateTime? NgayLapHd { get; set; }

    public string? MaKh { get; set; }

    public string? MaNv { get; set; }

    public int? TongTienHd { get; set; }

    public double? GiamGiaHd { get; set; }

    public byte? PhuongThucThanhToan { get; set; }

    public virtual TKhachHang? MaKhNavigation { get; set; }

    public virtual TNhanVien? MaNvNavigation { get; set; }

    public virtual ICollection<TChiTietHdb> TChiTietHdbs { get; } = new List<TChiTietHdb>();
}
