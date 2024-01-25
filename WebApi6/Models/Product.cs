using System.ComponentModel.DataAnnotations;

namespace WebApi6.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
       

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
