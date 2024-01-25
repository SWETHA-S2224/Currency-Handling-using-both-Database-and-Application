using System.ComponentModel.DataAnnotations;

namespace WebApi6.Models
{
    public class ProductCheck
    {

        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        [ConcurrencyCheck]
        public Guid Version { get; set; }
    }
}
