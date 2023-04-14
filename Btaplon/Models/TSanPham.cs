using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Btaplon.Models;

public partial class TSanPham
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public int? GiaNhap { get; set; }

    public int? GiaBan { get; set; }

    public string? MaDd { get; set; }

    public string? MaCl { get; set; }

    public string? MaLoai { get; set; }

    public string? MaNcc { get; set; }

    public string? AnhDaiDien { get; set; }

    public double? Vote { get; set; }

    public int? Slvote { get; set; }

    public virtual TChatlieuSp? MaClNavigation { get; set; }

    public virtual TDacDiem? MaDdNavigation { get; set; }

    public virtual TLoaiSp? MaLoaiNavigation { get; set; }

    public virtual TNhaCungCap? MaNccNavigation { get; set; }

    public virtual ICollection<TAnhSp> TAnhSps { get; } = new List<TAnhSp>();

    public virtual ICollection<TChiTietSp> TChiTietSps { get; } = new List<TChiTietSp>();
    [Display(Name = "Front Image")]
    [NotMapped]
    public IFormFile? FrontImage { get; set; }
}
