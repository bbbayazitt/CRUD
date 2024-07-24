using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet <Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                  new Customer { Id = 1, FirstName = "Burak", LastName = "Bayazit", Email = "burakbayazit@gmail.com" },
                  new Customer { Id = 2, FirstName = "Kerem", LastName = "Kul", Email = "keremkul@gmail.com" }



                  );
        }
    }
}
