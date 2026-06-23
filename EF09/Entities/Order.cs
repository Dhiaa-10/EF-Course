using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EF09.Entities
{
    [Table("Orders",Schema = "Sales"), PrimaryKey("Id")]
    public class Order
    {
        public int Id { get; set; }
        public string? CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
