using System;
using System.Collections.Generic;

namespace Btaplon.Models;

public partial class OrderDetail
{
    public string MaSp { get; set; } = null!;

    public long OderId { get; set; }

    public int? Quanlity { get; set; }

    public decimal? Price { get; set; }

    public long? Id { get; set; }

    public virtual Order? IdNavigation { get; set; }
}
