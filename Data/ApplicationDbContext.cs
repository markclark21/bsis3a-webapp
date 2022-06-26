using Microsoft.EntityFrameworkCore;
using bsis3a_webapp.Models;


namespace bsis3a_webapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base (options)
        {
            
        }

        public DbSet<item> items { get; set; }
        public DbSet<type> types {get;set;}

        

       

    }
}