using CompMarketReal.Models.Data.Tovars;
using CompMarketReal.Models.Data.Tovars.ComputerItems;
using CompMarketReal.Models.Data.UsersFolder;
using Microsoft.EntityFrameworkCore;

namespace CompMarketReal.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
       public DbSet<Computer>? computers { get; set; }
       public DbSet<Category> categories { get; set; }
       // Элементы компьютера
       public DbSet<Components> components { get; set; }    
       public DbSet<componetnType> componentTypes { get; set; }
       //Пользователи
       public DbSet<Users> users { get; set; }
       public DbSet<Role> roles { get; set; }
    }
}
