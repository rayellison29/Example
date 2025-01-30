using ForDemoApplication.Models;
using Microsoft.EntityFrameworkCore;
using static Views.Home;

namespace ForDemoApplication.Views.Home
{
    public class ForDemoApplicationDBContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public ForDemoApplicationDBContext(DbContextOptions<ForDemoApplicationDBContext> options)
                : base(options)
        {

        }
    }
}
