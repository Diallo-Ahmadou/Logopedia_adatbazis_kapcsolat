using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Logopédia_adatbázis_kapcsolat.Models
{
    public partial class LogopédiaContext : DbContext
    {
        public LogopédiaContext()
        {
        }

        public LogopédiaContext(DbContextOptions<LogopédiaContext> options) : base(options)
        {
        }

        public virtual DbSet<Diagnózisok> Diagnózisok { get; set; }
        public virtual DbSet<Eredmények> Eredmények { get; set; }
        public virtual DbSet<Gyerek_elérhetőségek> Gyerek_Elérhetőségek { get; set; }
        public virtual DbSet<Gyerekek> Gyerekek { get; set; }
        public virtual DbSet<Óvodák> Óvodák { get; set; }
        public virtual DbSet<Szakemberek> Szakemberek { get; set; }
        public virtual DbSet<Terápiák> Terápiák { get; set; }
        public virtual DbSet<Tesztek> Tesztek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;database=logopedia", ServerVersion.Parse("10.4.6-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
