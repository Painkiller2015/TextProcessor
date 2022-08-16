using Microsoft.EntityFrameworkCore;
using TextProcessor.Models;

namespace TextProcessor.DataBase
{
    internal class DB_Context : DbContext
    {
        public DB_Context()
        {
            Database.EnsureCreated();
        }
        public DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TextProcessor;Trusted_Connection=True;");
        }
    }
}
