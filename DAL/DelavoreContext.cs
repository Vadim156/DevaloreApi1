using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;

namespace DAL
{
    public class DelavoreContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public DelavoreContext()
        {
            
        }
        public DelavoreContext(DbContextOptions<DelavoreContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DelavoreContext");
            }
        }
    }
}