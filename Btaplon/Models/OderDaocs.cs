namespace Btaplon.Models
{
    public class OderDaocs
    {
        QlWebQuanAoContext db = null;
        public OderDaocs() { 
        db = new QlWebQuanAoContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);   
            db.SaveChanges();
            return order.Id;
        }
    }
}
