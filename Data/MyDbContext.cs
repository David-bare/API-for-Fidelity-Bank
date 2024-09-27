using FidelityGhanaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FidelityGhanaApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
        }
        public DbSet<User> digipass_users { get; set; }
        public DbSet<credentials> digipass { get; set; }
    }
}
