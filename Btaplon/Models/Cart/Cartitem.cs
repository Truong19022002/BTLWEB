namespace Btaplon.Models.Cart
{
    [Serializable]
    public class Cartitem
    {
        public TSanPham sanPham { get; set; }
        public int Quantity { get; set; }
        // các thuộc tính khác của đối tượng Cartitem
    }
}
