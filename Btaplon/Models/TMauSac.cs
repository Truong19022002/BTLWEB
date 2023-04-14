using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TMauSac
{
    public string MaMauSac { get; set; } = null!;

    public string? TenMauSac { get; set; }

    public virtual ICollection<TChiTietSp> TChiTietSps { get; } = new List<TChiTietSp>();
}
