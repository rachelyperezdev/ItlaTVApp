using ItlaTVApp.Core.Domain.Common;
using ItlaTVApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaTVApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        DbSet<Productora> Productoras { get; set; }
        DbSet<Genero> Generos { get; set; }
        DbSet<Serie> Series { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        entry.Property("CreatedBy").IsModified = false;
                        entry.Property("Created").IsModified = false;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region tables
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Serie>().ToTable("Series");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Productora>().HasKey(productora => productora.Id);
            modelBuilder.Entity<Genero>().HasKey(genero => genero.Id);
            modelBuilder.Entity<Serie>().HasKey(serie => serie.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Productora>().HasMany<Serie>(productora => productora.Series)
                .WithOne(serie => serie.Productora)
                .HasForeignKey(serie => serie.ProductoraId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Genero>().HasMany<Serie>(genero => genero.SeriesPrimarias)
                .WithOne(serie => serie.GeneroPrimario)
                .HasForeignKey(serie => serie.GeneroPrimarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Genero>().HasMany<Serie>(genero => genero.SeriesSecundarias)
                .WithOne(serie => serie.GeneroSecundario)
                .HasForeignKey(serie => serie.GeneroSecundarioId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region "property configurations"
            #region productoras
            modelBuilder.Entity<Productora>()
                .Property(productora => productora.Nombre)
                .IsRequired();
            #endregion
            #region generos
            modelBuilder.Entity<Genero>()
                .Property(genero => genero.Nombre)
                .IsRequired();
            #endregion
            #region series
            modelBuilder.Entity<Serie>()
                .Property(serie => serie.Nombre)
                .IsRequired();
            modelBuilder.Entity<Serie>()
                .Property(serie => serie.URLImagen)
                .IsRequired();
            modelBuilder.Entity<Serie>()
                .Property(serie => serie.URLVideo)
                .IsRequired();
            #endregion
            #endregion
        }
    }
}
