using Btaplon.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using X.PagedList;

namespace Btaplon.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("admin")]

    public class HomeAdminController : Controller
    {
        IWebHostEnvironment webhost;
        public HomeAdminController(IWebHostEnvironment webhost)
        {
            this.webhost = webhost;
        }
        QlWebQuanAoContext db = new QlWebQuanAoContext();
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            if (HttpContext.Request.Headers["Referer"].ToString() != "https://localhost:7295/")
            {
                return RedirectToAction("Index", "Home");
            }
           
            return View();
        }

        [Route("DanhSachSanPham")]
        public IActionResult DanhSachSanPham()
        {


            var listsanpham = db.TSanPhams.AsNoTracking().OrderBy(x => x.TenSp);

            return View(listsanpham);
        }
        [Route("DanhSachDonHang")]
        public IActionResult DanhSachDonHang()
        {


            var lstDonHang = db.Orders.AsNoTracking().OrderBy(x => x.TenKh);

            return View(lstDonHang);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var listChiTiet = db.TChiTietSps.Where(x => x.MaSp == maSanPham);
            foreach (var item in listChiTiet)
            {
                if (db.TChiTietHdbs.Where(x => x.MaChiTietSp == item.MaChiTietSp) != null)
                {
                    TempData["Message"] = "Khong xoa duoc san pham nay";
                    return RedirectToAction("DanhSachSanPham");
                }
            }
            var listAnh = db.TAnhSps.Where(x => x.MaSp == maSanPham);
            if (listAnh != null) db.RemoveRange(listAnh);
            if (listChiTiet != null) db.RemoveRange(listChiTiet);
            db.Remove(db.TSanPhams.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "San pham da duoc xoa";
            return RedirectToAction("DanhSachSanPham");
        }
        [Route("ThemSanPham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.MaDd = new SelectList(db.TDacDiems.ToList(), "MaDd", "TenDd");
            ViewBag.MaCl = new SelectList(db.TChatlieuSps.ToList(), "MaCl", "TenCl");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaNcc = new SelectList(db.TNhaCungCaps.ToList(), "MaNcc", "TenNcc");
            return View();
        }
        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(TSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
				// Kiểm tra Tên SP chỉ chứa chữ cái và không chứa số
				//if (!Regex.IsMatch(sanPham.TenSp, "^[a-zA-Z]+$"))
				//{
				//	ModelState.AddModelError(nameof(sanPham.TenSp), "Tên sản phẩm chỉ được chứa chữ cái và không được chứa số.");
				//}

				//// Kiểm tra định dạng ảnh đại diện
				//if (sanPham.AnhDaiDien != null && Path.GetExtension(sanPham.AnhDaiDien) != ".jpg")
				//{
				//	ModelState.AddModelError(nameof(sanPham.AnhDaiDien), "Ảnh đại diện phải có định dạng .jpg.");
				//}



				string uniqueFileName = Uploade(sanPham);
                if (uniqueFileName == "")
                {
                    uniqueFileName = "ao_khoac_da_nam.jpg";
                }
                sanPham.AnhDaiDien = uniqueFileName;
                db.TSanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham", "Admin");
            }
            return View(sanPham);
        }
        [Route("NamDinh")]
        public string Uploade(TSanPham sanPham)
        {
            string uniqueFileName = null;
            if (sanPham.FrontImage != null)
            {
                string uploadFolder = Path.Combine(webhost.WebRootPath, "ProductsImages/img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + sanPham.FrontImage.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    sanPham.FrontImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [Route("SuaSanPham")]
        [HttpGet]

        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaDd = new SelectList(db.TDacDiems.ToList(), "MaDd", "TenDd");
            ViewBag.MaCl = new SelectList(db.TChatlieuSps.ToList(), "MaCl", "TenCl");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaNcc = new SelectList(db.TNhaCungCaps.ToList(), "MaNcc", "TenNcc");
            var sanPham = db.TSanPhams.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TSanPham sanPham)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = Uploade(sanPham);
                if (uniqueFileName == "")
                {
                    uniqueFileName = "ao_khoac_da_nam.jpg";
                }
                sanPham.AnhDaiDien = uniqueFileName;
                //db.Entry(sanPham).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                db.Update(sanPham);
				db.SaveChanges();
				return RedirectToAction("DanhSachSanPham");

            }
            return View(sanPham);
        }
        
		[Route("DanhSachKH")]
		public IActionResult DanhSachKH()
		{


			var khachHangs = db.TKhachHangs.AsNoTracking().OrderBy(x => x.TenKh);

			return View(khachHangs);
		}
		//Thêm, sửa xóa KH
		[Route("ThemKhachHang")]
        [HttpGet]
        public IActionResult ThemKhachHang()
        {
            ViewBag.Username = new SelectList(db.TUsers.ToList(), "Password", "Username");
            return View();
        }
        [Route("ThemKhachHang")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemKhachHang(TKhachHang khachHang)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = UploadeKH(khachHang);
                if (uniqueFileName == "")
                {
                    uniqueFileName = "img2-large_bk.jpg";
                }
                khachHang.AnhDaiDien = uniqueFileName;
                db.TKhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("DanhSachKH", "Admin");
            }
            return View(khachHang);
        }
        [Route("NamDinh")]
        public string UploadeKH(TKhachHang khachHang)
        {
            string uniqueFileName = null;
            if (khachHang.FrontImage != null)
            {
                string uploadFolder = Path.Combine(webhost.WebRootPath, "KHImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + khachHang.FrontImage.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    khachHang.FrontImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [Route("SuaKhachHang")]
        [HttpGet]

        public IActionResult SuaKhachHang(string maKH)
        {
           
            var khachHang = db.TKhachHangs.Find(maKH);
            return View(khachHang);
        }
        [Route("SuaKhachHang")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaKhachHang(TKhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadeKH(khachHang);
                if (uniqueFileName == "")
                {
                    uniqueFileName = "img2-large_bk.jpg";
                }
				db.Update(khachHang);
				db.SaveChanges();
				return RedirectToAction("SuaKhachHang");

            }
            return View(khachHang);
        }
		[Route("XoaKhachHang")]
		public IActionResult XoaKhachHang(string maKH)
		{
			TempData["Message"] = "";
			var listChiTiet = db.THoaDonBans.Where(x => x.MaKh == maKH);
			foreach (var item in listChiTiet)
			{
				if (db.THoaDonBans.Where(x => x.SoHdb == item.SoHdb) != null)
				{
					TempData["Message"] = "Khong xoa duoc KH nay";
					return RedirectToAction("DanhSachKH");
				}
			}
			if (listChiTiet != null) db.RemoveRange(listChiTiet);
			var listOrder = db.Orders.Where(x => x.MaKh == maKH);
			if (listOrder != null) db.RemoveRange(listOrder);
			db.Remove(db.TKhachHangs.Find(maKH));
			db.SaveChanges();
			TempData["Message"] = "Nhan vien da duoc xoa";
			return RedirectToAction("DanhSachNV");
		}
        [Route("DanhSachNV")]
        public IActionResult DanhSachNV()
        {


            var nhanVien = db.TNhanViens.AsNoTracking().OrderBy(x => x.TenNv);

            return View(nhanVien);
        }
        [Route("ThemNhanVien")]
		[HttpGet]
		public IActionResult ThemNhanVien()
		{
			
			ViewBag.MaCv = new SelectList(db.TChucVus.ToList(), "MaCv", "TenCv");
			return View();
		}
		[Route("ThemNhanVien")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ThemNhanVien(TNhanVien nhanVien)
		{
			if (ModelState.IsValid)
			{
                
                string uniqueFileName = UploadeNV(nhanVien);
				if (uniqueFileName == "")
				{
					uniqueFileName = "img2-large.jpg";
				}
				nhanVien.AnhDaiDien = uniqueFileName;
				db.TNhanViens.Add(nhanVien);
				db.SaveChanges();
				return RedirectToAction("DanhSachNV", "Admin");
			}
			return View(nhanVien);
		}
		[Route("NamDinh")]
		public string UploadeNV(TNhanVien nhanVien)
		{
			string uniqueFileName = null;
			if (nhanVien.FrontImage != null)
			{
				string uploadFolder = Path.Combine(webhost.WebRootPath, "NVImages");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + nhanVien.FrontImage.FileName;
				string filePath = Path.Combine(uploadFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					nhanVien.FrontImage.CopyTo(fileStream);
				}
			}
			return uniqueFileName;
		}

		[Route("SuaNhanVien")]
		[HttpGet]

		public IActionResult SuaNhanVien(string maNV)
		{
			
			ViewBag.MaCv = new SelectList(db.TChucVus.ToList(), "MaCv", "TenCv");
			var nhanVien = db.TKhachHangs.Find(maNV);
			return View(nhanVien);
		}
		[Route("SuaNhanVien")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SuaNhanVien(TNhanVien nhanVien)
		{
			if (ModelState.IsValid)
			{
                string uniqueFileName = UploadeNV(nhanVien);
                if (uniqueFileName == "")
                {
                    uniqueFileName = "img2-large.jpg";
                }
				db.Update(nhanVien);
				db.SaveChanges();
				return RedirectToAction("SuaNhanVien");

			}
			return View(nhanVien);
		}
		[Route("XoaNhanVien")]
		public IActionResult XoaNhanVien(string maNV)
		{
			TempData["Message"] = "";
			var listChiTiet = db.THoaDonBans.Where(x => x.MaNv == maNV);
			foreach (var item in listChiTiet)
			{
				if (db.THoaDonBans.Where(x => x.SoHdb == item.SoHdb) != null)
				{
					TempData["Message"] = "Khong xoa duoc nhanvien nay";
					return RedirectToAction("DanhSachNV");
				}
			}
			if (listChiTiet != null) db.RemoveRange(listChiTiet);
			db.Remove(db.TNhanViens.Find(maNV));
			db.SaveChanges();
			TempData["Message"] = "Nhan vien da duoc xoa";
			return RedirectToAction("DanhSachNV");
		}
	}
}