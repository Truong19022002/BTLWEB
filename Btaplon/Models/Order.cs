using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class Order
{
    public long Id { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? MaKh { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public int? Status { get; set; }

    public string? TenKh { get; set; }

    public virtual TKhachHang? MaKhNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
