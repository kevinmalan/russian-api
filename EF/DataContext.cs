using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Alphabet> Alphabet { get; set; }
        public DbSet<Phrase> Phrases { get; set; }
    }
}