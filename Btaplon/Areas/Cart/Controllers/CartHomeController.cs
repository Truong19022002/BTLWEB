using Btaplon.Models;
using Btaplon.Models.Cart;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Btaplon.Areas.Cart.Controllers
{
    [Area("cart")]
    [Route("cart")]

    public class CartHomeController : Controller
    {
        QlWebQuanAoContext db = new QlWebQuanAoContext();

        private const string CartSession = "CartSession";

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            TempData["Message"] = "Sản phẩm đã được thêm vào giỏ hàng";
            var cart = HttpContext.Session.GetString(CartSession);
            var list = new List<Cartitem>();
            if (cart != null)
            {
                var productList = JsonConvert.DeserializeObject<List<Cartitem>>(cart);
                list = productList;
            }
            return View(list);
        }

        [Route("AddiItem")]
        public ActionResult AddiItem(string id, int quantity)
        {
            var cart = HttpContext.Session.GetString(CartSession);
            if (cart != null)
            {
                var productList = JsonConvert.DeserializeObject<List<Cartitem>>(cart);
                var item = productList.Find(p => p.sanPham.MaSp == Convert.ToString(id));
            
                if (item != null)
                {
                    item.Quantity += quantity;
                }
                else
                {
                    var sanPham = db.TSanPhams.Find(id);
                    if (sanPham != null)
                    {
                        item = new Cartitem();
                        item.sanPham = sanPham;
                        item.Quantity = quantity;
                        productList.Add(item);
                    }
                }
                cart = JsonConvert.SerializeObject(productList);
                HttpContext.Session.SetString(CartSession, cart);
            }
            else
            {
                var sanPham = db.TSanPhams.Find(id);
                if (sanPham != null)
                {
                    var item = new Cartitem();
                    item.sanPham = sanPham;
                    item.Quantity = quantity;
                    var list = new List<Cartitem>();
                    list.Add(item);
                    cart = JsonConvert.SerializeObject(list);
                    HttpContext.Session.SetString(CartSession, cart);
                }
            }
            return RedirectToAction("Index");
        }

        [Route("RemoveItem")]
        public IActionResult RemoveItem(string id)
        {
            var cart = HttpContext.Session.GetString(CartSession);
            if (cart != null)
            {
                var productList = JsonConvert.DeserializeObject<List<Cartitem>>(cart);
                var item = productList.Find(p => p.sanPham.MaSp == Convert.ToString(id));
                if (item != null)
                {
                    productList.Remove(item);
                    cart = JsonConvert.SerializeObject(productList);
                    HttpContext.Session.SetString(CartSession, cart);
                }
            }
            return RedirectToAction("Index");
        }
        [Route("ClearCart")]
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove(CartSession); // Xóa session giỏ hàng
            return RedirectToAction("Index");
        }

        [Route("Payment")]
        [HttpGet]
        public IActionResult Payment()
        {
            TempData["Message"] = "Sản phẩm đã được thêm vào giỏ hàng";
            var cart = HttpContext.Session.GetString(CartSession);
            var list = new List<Cartitem>();
            if (cart != null)
            {
                var productList = JsonConvert.DeserializeObject<List<Cartitem>>(cart);
                list = productList;
            }
            return View(list);
        }

        [Route("Payment")]
        [HttpPost]
        public IActionResult Payment(string CustomerName, string Email, string Phone, string Address)
        {
            TempData["Message"] = "Đặt hàng thành công";
            var cart = HttpContext.Session.GetString(CartSession);
            var list = new List<Cartitem>();
            if (cart != null)
            {
                list = JsonConvert.DeserializeObject<List<Cartitem>>(cart);
            }
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    CreatedDate = DateTime.Now,
                    DiaChi = Address,
                    TenKh = CustomerName,
                    Email = Email,
                    Sdt = Phone
                };
                db.Orders.Add(order);
                db.SaveChanges();
                var orderId = order.Id;
                foreach (var item in list)
                {
                    var orderDetail = new OrderDetail
                    {
                        OderId = orderId,
                        MaSp = item.sanPham.MaSp,
                        Quanlity = item.Quantity,
                        Price = item.sanPham.GiaBan
                    };
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                }
                HttpContext.Session.Remove(CartSession);
                return RedirectToAction("Success", "Cart");
            }
            return View(list);
        }

        [Route("Success")]
        public ActionResult Success()
        {
            return View();
        }

    }
}