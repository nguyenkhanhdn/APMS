namespace APMS.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class ParkingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<ParkingTransaction> ParkingTransactions { get; set; }
        public DbSet<ParkingAvailability> ParkingAvailabilities { get; set; }

        public ParkingDbContext(DbContextOptions<ParkingDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
        }

        public DbSet<APMS.Models.Tariff> Tariff { get; set; } = default!;
        public DbSet<APMS.Models.UserPaymentTracking> UserPaymentTracking { get; set; } = default!;

        public void VehicleEntry()
        {
            var availability = ParkingAvailabilities.FirstOrDefault();
            if (availability != null && availability.AvailableSlots > 0)
            {
                availability.AvailableSlots--;
                SaveChanges();
            }
        }
        public void VehicleExit()
        {
            var availability = ParkingAvailabilities.FirstOrDefault();
            if (availability != null)
            {
                availability.AvailableSlots++;
                SaveChanges();
            }
        }
    }
    public class ParkingAvailability
    {
        public int Id { get; set; }
        public int TotalSlots { get; set; }
        public int AvailableSlots { get; set; }
    }

    public class User
    {
        [Display(Name = "User ID")]
        public int UserId { get; set; }
        [Display(Name = "Chủ xe")]
        public string FullName { get; set; }
        [Display(Name = "Thư điện tử")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Vai trò")]
        public string Role { get; set; }
        [Display(Name = "Số dư")]
        public string Balance { get; set; }
    }

    public class VehicleType
    {
        [Display(Name = "Loại xe ID")]
        public int VehicleTypeId { get; set; }
        [Display(Name = "Loại xe")]
        public string TypeName { get; set; }
        [Display(Name = "Ảnh mô tả")]
        public string DescriptionImage { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }

    public class Vehicle
    {
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }
        [Display(Name = "Biển số xe")]
        public string LicensePlate { get; set; }
        [Display(Name = "Chủ xe")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Display(Name = "Loại xe")]
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }

    public class ParkingSlot
    {
        [Display(Name = "Parking Slot ID")]
        public int ParkingSlotId { get; set; }
        [Display(Name = "Số hiệu")]
        public string SlotNumber { get; set; }
        
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
    }

    public class ParkingTransaction
    {
        public int ParkingTransactionId { get; set; }
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }
        
        public Vehicle Vehicle { get; set; }
        [Display(Name = "Parking Slot ID")]
        public int ParkingSlotId { get; set; }
        public ParkingSlot ParkingSlot { get; set; }
        
        [Display(Name = "Thời gian vào")]
        public DateTime EntryTime { get; set; }
        [Display(Name = "Thời gian ra")]
        public DateTime? ExitTime { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal? TotalAmount { get; set; }
    }

    public class Tariff
    {
        [Key]
        public int TariffId { get; set; }
        [Display(Name = "Tên gói cước")]
        public string TariffName { get; set; }
        [Display(Name = "Giá tiền")]
        public decimal Price { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }

    public class UserPaymentTracking
    {
        public int Id { get; set; }
        [Display(Name = "User ID")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Display(Name = "Tariff ID")]
        public int TariffId { get; set; }
        public Tariff Tariff { get; set; }
        [Display(Name = "Ngày thanh toán")]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Số tiền")]
        public float Amount { get; set; }
        [Display(Name = "Đã thanh toán")]
        public bool IsPaid { get; set; }
    }
}
