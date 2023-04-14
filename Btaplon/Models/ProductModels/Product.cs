namespace Btaplon.Models.ProductModels
{
    public class Product
    {
        public string MaSp { get; set; } = null!;

        public string TenSp { get; set; } = null!;
        public string MaLoai { get; set; } = null!;
        public string? AnhDaiDien { get; set; }
        public decimal? GiaBan { get; set; }
    }
}
