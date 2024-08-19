using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace UserApp.DAL;

public class UserContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseInMemoryDatabase("UserDatabase");
    }

    public DbSet<User> Users { get; set; }
}
