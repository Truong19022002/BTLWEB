using Btaplon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Btaplon.Controllers
{
	public class AccessController : Controller
	{
		QlWebQuanAoContext db = new QlWebQuanAoContext();

		public IActionResult Login()
		{
			if (Request.Cookies["UserName"] == null)
			{
				return View();
			}
			else return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult Login(TUser user)
		{

			if (Request.Cookies["UserName"] == null)
			{
				var u = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
				if (u != null && u.LoaiUser == 1)
				{
					Response.Cookies.Append("UserName", u.Username.ToString());
					return RedirectToAction("Index", "admin");
				}
				if (u != null && u.LoaiUser == 0)
				{
					Response.Cookies.Append("UserName", u.Username.ToString());
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
					return View(user);
				}
			}
			return View();
		}
		[Route("Themtaikhoan")]
		[HttpGet]
		public IActionResult Themtaikhoan()
		{
			return View();
		}
		[HttpPost]
		[Route("Themtaikhoan")]
		public IActionResult Themtaikhoan(TUser user)
		{
			if (ModelState.IsValid)
			{
				if (user.Password.Length < 8)
				{
					ModelState.AddModelError("", "Mật khẩu phải có ít nhất 8 ký tự.");
					return View(user);
				}

				db.TUsers.Add(user);
				db.SaveChanges();
				return RedirectToAction("Login");
			}
			return View(user);
		}
		public IActionResult Logout()
		{
			Response.Cookies.Delete("UserName");
			return RedirectToAction("Login", "Access");
		}
	}
}