namespace Btaplon.Models
{
    public class OrderDetailDao
    {

        QlWebQuanAoContext db = null;
        public OrderDetailDao()
        {
            db = new QlWebQuanAoContext();
        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
             
                return false;
            }
        }
    }
}
