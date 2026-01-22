using Microsoft.EntityFrameworkCore;
using Prop.Api.Domain;

namespace Prop.Api.Persistence
{
    public class PropDbContext : DbContext
    {
        public PropDbContext(DbContextOptions<PropDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Quote> Quotes => Set<Quote>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------
            // CLIENT
            // -------------------------
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.FirstName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(c => c.LastName)
                      .HasMaxLength(200)
                      .IsRequired(false);

                entity.Property(c => c.Email)
                      .HasMaxLength(100)
                      .IsRequired(false);

                entity.Property(c => c.Phone)
                      .HasMaxLength(30)
                      .IsRequired(false);

                // Relacja 1:1 z Address
                entity.HasOne(c => c.Address)
                      .WithOne(a => a.Client)
                      .HasForeignKey<Address>(a => a.ClientId);

                // Relacja 1:N z Quote
                entity.HasMany(c => c.Quotes)
                      .WithOne(q => q.Client)
                      .HasForeignKey(q => q.ClientId);
            });

            // -------------------------
            // ADDRESS
            // -------------------------
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Street)
                      .HasMaxLength(200)
                      .IsRequired(false);

                entity.Property(a => a.HomeNumber)
                      .HasMaxLength(50)
                      .IsRequired(false);

                entity.Property(a => a.City)
                      .HasMaxLength(100)
                      .IsRequired(false);

                entity.Property(a => a.PostalCode)
                      .HasMaxLength(20)
                      .IsRequired(false);

                entity.Property(a => a.Country)
                      .HasMaxLength(100)
                      .IsRequired(false);

                entity.Property(a => a.PermanentResidence)
                    .HasMaxLength(5)
                    .IsRequired(true);
            });

            // -------------------------
            // QUOTE
            // -------------------------
            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasKey(q => q.Id);

                entity.Property(q => q.PropertyArea)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(q => q.PropertyYear)
                      .IsRequired();

                entity.Property(q => q.HasSecuritySystem)
                      .IsRequired();

                entity.Property(q => q.Premium)
                      .HasColumnType("decimal(18,2)");

                entity.Property(q => q.CreatedAt)
                      .IsRequired();

                entity.Property(q => q.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(q => q.ClaimNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(q => q.Floor)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(q => q.TopFloor)
                    .IsRequired();

                entity.Property(q => q.FlammableFloor)
                    .IsRequired();
            });
        }
    }
}
