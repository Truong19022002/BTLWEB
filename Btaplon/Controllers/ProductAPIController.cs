using Btaplon.Models;
using Btaplon.Models.ProductModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Btaplon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlWebQuanAoContext db= new QlWebQuanAoContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {

            var sanPham = (from p in db.TSanPhams
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaBan = p.GiaBan,
                           }).ToList();
            return sanPham;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(string maLoai)
        {

            var sanPham = (from p in db.TSanPhams
                           where p.MaLoai == maLoai
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaBan = p.GiaBan,
                           }).ToList();
            return sanPham;
        }

    }
}
