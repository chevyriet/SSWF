using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EB_EF
{
    public class EBDbContext : DbContext
    {
        public DbSet<Cantina> Cantinas { get; set; }
        public DbSet<MealBox> MealBoxes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<MealBoxProduct> MealBoxesProducts { get; set; }

        public EBDbContext(DbContextOptions<EBDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<MealBox>()
            .HasMany(x => x.Products)
            .WithMany(x => x.MealBoxes)
            .UsingEntity<MealBoxProduct>(
                x => x.HasOne(mb => mb.Product).WithMany().HasForeignKey(mb => mb.ProductId),

                x => x.HasOne(mb => mb.MealBox).WithMany().HasForeignKey(mb => mb.MealBoxId));

            base.OnModelCreating(modelBuilder);
        }
    }
}
