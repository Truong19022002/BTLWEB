using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Btaplon.Models;

public partial class TNhanVien
{
    public string MaNv { get; set; } = null!;

    public string? TenNv { get; set; }

    public string? MaCv { get; set; }

    public string? Username { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public int? Sdt { get; set; }

    public int? Luong { get; set; }

    public string? AnhDaiDien { get; set; }

    public virtual TChucVu? MaCvNavigation { get; set; }

    public virtual ICollection<THoaDonBan> THoaDonBans { get; } = new List<THoaDonBan>();

    public virtual TUser? UsernameNavigation { get; set; }
    [Display(Name = "Front Image")]
    [NotMapped]
    public IFormFile? FrontImage { get; set; }
}
