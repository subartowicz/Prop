using Microsoft.EntityFrameworkCore;
using Prop.Api.Domain;

namespace Prop.Api.Persistence
{
    public class PropDbContext : DbContext
    {
        public PropDbContext(DbContextOptions<PropDbContext> options) : base(options)
        {
        }

        public DbSet<Quote> Quotes => Set<Quote>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasKey(q => q.Id);

                entity.Property(q => q.ClientName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(q => q.ClientLastName)
                      .HasMaxLength(200)
                      .IsRequired(false);

                entity.Property(q => q.ClientEmail)
                      .HasMaxLength(50)
                      .IsRequired(false);
                entity.Property(q => q.ClientPhone)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(q => q.Street)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(q => q.HomeNumber)
                      .IsRequired()
                      .HasMaxLength(10);

                entity.Property(q => q.City)
                      .IsRequired()
                        .HasMaxLength(50);

                entity.Property(q => q.PostalCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(q => q.Country)
                      .IsRequired()
                      .HasMaxLength(3);

                entity.Property(q => q.PropertyArea)
                      .HasColumnType("decimal(18,2)")   // ← poprawiony decimal
                      .IsRequired();

                entity.Property(q => q.PropertyYear)
                      .IsRequired();

                entity.Property(q => q.HasSecuritySystem)
                      .IsRequired();

                entity.Property(q => q.Premium)
                      .HasColumnType("decimal(18,2)");  // ← poprawiony decimal

                entity.Property(q => q.CreatedAt)
                      .IsRequired();
            });
        }
    }
}
