using Microsoft.EntityFrameworkCore;

namespace bookapi;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {

    }

    public virtual DbSet<Book> Books{get;set;}

}
