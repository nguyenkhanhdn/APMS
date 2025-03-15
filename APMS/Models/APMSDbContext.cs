using Microsoft.EntityFrameworkCore;
using APMS.Models;
namespace APMS.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ParkingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<ParkingTransaction> ParkingTransactions { get; set; }

        public ParkingDbContext(DbContextOptions<ParkingDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ràng buộc khóa ngoại
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleType)
                .WithMany()
                .HasForeignKey(v => v.VehicleTypeId);

            modelBuilder.Entity<ParkingTransaction>()
                .HasOne(pt => pt.Vehicle)
                .WithMany()
                .HasForeignKey(pt => pt.VehicleId);

            modelBuilder.Entity<ParkingTransaction>()
                .HasOne(pt => pt.ParkingSlot)
                .WithMany()
                .HasForeignKey(pt => pt.SlotId);

            modelBuilder.Entity<ParkingTransaction>()
                .HasOne(pt => pt.User)
                .WithMany()
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserPaymentTracking>()
           .HasOne(up => up.User)
           .WithMany()
           .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPaymentTracking>()
                .HasOne(up => up.Tariff)
                .WithMany()
                .HasForeignKey(up => up.TariffId);
        }

public DbSet<APMS.Models.Tariff> Tariff { get; set; } = default!;

public DbSet<APMS.Models.UserPaymentTracking> UserPaymentTracking { get; set; } = default!;
    }

    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }

    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal PricePerHour { get; set; }
    }

    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string OwnerName { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }

    public class ParkingSlot
    {
        public int ParkingSlotId { get; set; }
        public string SlotNumber { get; set; }
        public string Status { get; set; }
    }

    public class ParkingTransaction
    {
        public int ParkingTransactionId { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int SlotId { get; set; }
        public ParkingSlot ParkingSlot { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class Tariff
    {
        public int TariffId { get; set; }
        public string TariffName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class UserPaymentTracking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TariffId { get; set; }
        public Tariff Tariff { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Amount { get; set; }
        public bool IsPaid { get; set; }
    }
}
