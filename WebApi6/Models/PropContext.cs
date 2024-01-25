using Microsoft.EntityFrameworkCore;

namespace WebApi6.Models
{
    public class PropContext :DbContext
    {
        public PropContext(DbContextOptions options):base(options) 
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCheck> Productcheck { get; set; }
    }
}
