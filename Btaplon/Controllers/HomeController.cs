using Azure;
using Btaplon.Models;
using Btaplon.Models.Authentication;
using Btaplon.ViewModels;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using X.PagedList;

namespace Btaplon.Controllers
{
    public class HomeController : Controller
    {
        QlWebQuanAoContext db = new QlWebQuanAoContext();
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {

            //int pageSize = 6;
            //int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstcsanpham = db.TSanPhams.AsNoTracking().OrderBy(x => x.TenSp);
            var threeitem = (from a in db.TSanPhams
                             where a.MaCl == "cot"
                             select new TSanPham()
                             {
                                 MaSp = a.MaSp,
                                 TenSp = a.TenSp,
                                 MaLoai = a.MaLoai,
                                 MaCl = a.MaCl,
                                 MaNcc = a.MaNcc,
                                 GiaBan = a.GiaBan,
                                 AnhDaiDien = a.AnhDaiDien
                             }).ToList();
            var towitem = (from a in db.TSanPhams
                           where a.MaCl == "lea"
                           select a).ToList();
            //PagedList<TSanPham> lst = new PagedList<TSanPham>(lstcsanpham, /*pageNumber*/, pageSize);
            var viewmodel = new ViewModel
            {
                newPhamList = towitem,
                sanPhams = lstcsanpham.ToList(),
                sanPhams2 = threeitem
            };
            return View(viewmodel);
        }
        //public IActionResult Vote(TSanPham sp)
        //{
        //    if (sp != null)
        //    {
        //        TSanPham sanp = db.TSanPhams.SingleOrDefault(x=>x.MaSp == sp.MaSp);
        //        double vote = (double)sanp.Vote;
        //        int Slvote = (int)sanp.Slvote;
        //        if(sp.Vote!=null)
        //        {
        //            double votenew = (vote * Slvote + double.Parse(sp.Vote.ToString()))/ Slvote;
        //            int soluotVoteNew = Slvote + 1;
        //            sanp.Vote = votenew;
        //            sanp.Slvote = soluotVoteNew;
        //            db.Entry(sanp).State=Microsoft.EntityFrameworkCore.EntityState.Modified;    
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    return RedirectToAction("ChiTietSanPham");
        //}
        public IActionResult Vote(TSanPham sp)
        {
            if (sp != null && sp.MaSp != null)
            {
                TSanPham sanp = db.TSanPhams.SingleOrDefault(x => x.MaSp == sp.MaSp);
                if (sanp != null && sp.Vote != null)
                {
                    double vote = (double)sanp.Vote;
                    int Slvote = (int)sanp.Slvote;
                    double votenew = (vote * Slvote + double.Parse(sp.Vote.ToString())) / (Slvote + 1);
                    sanp.Vote = votenew;
                    sanp.Slvote = Slvote + 1;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("ChiTietSanPham");
        }


        //[ActionName("ThreeItem")]
        //public IActionResult ThreeItem(int? page)
        //{
        //    int pageSize = 6;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    var lstcsanpham = db.TSanPhams.AsNoTracking().OrderBy(x => x.TenSp);
        //    PagedList<TSanPham> lst = new PagedList<TSanPham>(lstcsanpham, pageNumber, pageSize);
        //    return View(lst);
        //}
        public IActionResult ChiTietSanPham(string maSp)
        {
            var sanPham = db.TSanPhams.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }
        public IActionResult SanPhamTheoLoai(string maloai)
        {

            var lstcsanpham = db.TSanPhams.AsNoTracking().Where(x => x.MaLoai == maloai).OrderBy(x => x.TenSp);
            var threeitem = (from a in db.TSanPhams
                             where a.MaCl == "cot"
                             select new TSanPham()
                             {
                                 MaSp = a.MaSp,
                                 TenSp = a.TenSp,
                                 MaLoai = a.MaLoai,
                                 MaCl = a.MaCl,
                                 MaNcc = a.MaNcc,
                                 AnhDaiDien = a.AnhDaiDien
                             }).ToList();
            var towitem = (from a in db.TSanPhams
                           where a.MaCl == "li"
                           select a).ToList();
            //PagedList<TSanPham> lst = new PagedList<TSanPham>(lstcsanpham, /*pageNumber*/, pageSize);
            var viewmodel = new ViewModel
            {
                newPhamList = towitem,
                sanPhams = lstcsanpham.ToList(),
                sanPhams2 = threeitem
            };
            
           
            ViewBag.maloai = maloai;
            return View(viewmodel);
        }



        //public IActionResult ProductDetail(string maSanPham)
        //{
        //    var sanPham = db.TSanPhams.SingleOrDefault(x=>x.MaSp == maSanPham);
        //    var anhSanPham = db.TAnhSps.Where(x=>x.MaSp ==maSanPham).ToList();
        //    var homeProductDetailViewModel = new HomeProductDetailViewModel{
        //        sanPham=sanPham,
        //        anhSps=anhSanPham
        //    };

        //    return View(homeProductDetailViewModel);  
        //}
        public IActionResult TimKiemSanPham(string nameSanPham, int? page)
        {
            ViewBag.nameSanPham = nameSanPham;
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = db.TSanPhams.Where(x => x.TenSp.Contains(nameSanPham)).ToList();
            PagedList<TSanPham> lt = new PagedList<TSanPham>(lst, pageNumber, pageSize);
            return View(lt);
        }
        public IActionResult Admin()
        {
            return RedirectToAction("Index", "admin");
        }
        public IActionResult Cart()
        {
            return RedirectToAction("Index", "cart");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}