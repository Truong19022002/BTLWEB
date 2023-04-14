using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TKichCo
{
    public string MaKichCo { get; set; } = null!;

    public string? TenKichCo { get; set; }

    public virtual ICollection<TChiTietSp> TChiTietSps { get; } = new List<TChiTietSp>();
}
