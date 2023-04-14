using Btaplon.Models;
using Microsoft.AspNetCore.Mvc;
using Btaplon.Repository;

namespace ThucHanhOgani.ViewComponents
{
    public class LoaiSpMenuViewComponent:ViewComponent

    {
        private readonly lLoaiSpRepository _loaiSp;
        public LoaiSpMenuViewComponent(lLoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;

        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai); 
            return View(loaisp);
        }
    }
}
