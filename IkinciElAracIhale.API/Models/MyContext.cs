using IkinciElAracIhale.API.Models.Entities;
using IkinciElAracIhale.API.Models.VM;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Xml;

namespace IkinciElAracIhale.API.Models
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            optionsBuilder.UseSqlServer("Server=DESKTOP-4G2SJTP;Database=IkinciElArac;Trusted_Connection=True;");
            //modelBuilder.Entity<MyEntity>().Property(e => e.MyDateColumn).HasColumnType("datetime2");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ihale>()
           .Property(f => f.IhaleBaslangicTarihi)
           .HasColumnType("datetime2");
            modelBuilder.Entity<Ihale>()
           .Property(f => f.IhaleBitisTarihi)
           .HasColumnType("datetime2");
        }

        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Ihale> Ihale { get; set; }
        public DbSet<IhaleArac> IhaleArac { get; set; }
        public DbSet<IhaleStatu> IhaleStatu { get; set; }
        public DbSet<Arac> Arac { get; set; }
        public DbSet<AracMarka> AracMarka { get; set; }
        public DbSet<AracModel> AracModel { get; set; }
        public DbSet<IhaleFiyat> IhaleFiyat { get; set; }
    }




}

