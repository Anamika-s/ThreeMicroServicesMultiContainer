 
namespace OrderApi.Models
{
     public class Order
    {
         public string OrderId { get; set; }

         public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }


         public List<OrderDetail> OrderDetails { get; set; }
        }

}
