using Microsoft.EntityFrameworkCore;
using PopCornAndCritics.Models;

namespace PopCornAndCritics.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> opt):base(opt){}

    public DbSet<User> User { get; set; }

    public DbSet<Movie> Movie { get; set; }

    public DbSet<Comment> Comment { get; set; }
}
