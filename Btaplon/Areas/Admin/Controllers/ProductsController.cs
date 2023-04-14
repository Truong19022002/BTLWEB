using Btaplon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Btaplon.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        QlWebQuanAoContext db = new QlWebQuanAoContext();
        [HttpGet]
        public IEnumerable<TSanPham> GetAllCauthu()
        {
            return db.TSanPhams.ToList();
        }


    }
}
