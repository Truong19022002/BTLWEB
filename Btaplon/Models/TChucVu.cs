using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class TChucVu
{
    public string MaCv { get; set; } = null!;

    public string? TenCv { get; set; }

    public virtual ICollection<TNhanVien> TNhanViens { get; } = new List<TNhanVien>();
}
