using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Btaplon.Models;

public partial class TKhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public string? Username { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public int? Sdt { get; set; }

    public string? Email { get; set; }

    public string? AnhDaiDien { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<THoaDonBan> THoaDonBans { get; } = new List<THoaDonBan>();

    public virtual TUser? UsernameNavigation { get; set; }
    [Display(Name = "Front Image")]
    [NotMapped]
    public IFormFile? FrontImage { get; set; }
}
