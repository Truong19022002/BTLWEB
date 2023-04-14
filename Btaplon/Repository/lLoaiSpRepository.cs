using Btaplon.Models;
namespace Btaplon.Repository
{
    public interface lLoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp); 
        TLoaiSp Delete(string maloaiSp); 
        TLoaiSp GetLoaiSp(string maloaiSp);
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
