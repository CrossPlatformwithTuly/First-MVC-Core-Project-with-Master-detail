using CoreWebAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPIProject.DataContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base (options)
        {
            
        }
        public DbSet<SaleMaster> saleMasters { get; set; }
        public DbSet<SaleDetail> saleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleDetail>()
        .HasOne(sd => sd.saleMaster)
        .WithMany(sm => sm.saleDetail)
        .HasForeignKey(sd => sd.SaleId)
        .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
