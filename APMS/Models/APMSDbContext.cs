namespace APMS.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using System.ComponentModel.DataAnnotations;
    using static APMS.Models.Tariff;

    public class ParkingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ParkingAvailability> ParkingAvailabilities { get; set; }

        public DbSet<APMS.Models.UserPayment> UserPayments { get; set; }
        public DbSet<APMS.Models.Tariff> Tariff { get; set; } = default!;

        public ParkingDbContext(DbContextOptions<ParkingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

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
        [Display(Name = "Số chỗ")]
        public int TotalSlots { get; set; }
        [Display(Name = "Số chỗ còn trống")]
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
        public ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
        public ICollection<UserPayment> UserPayments { get; } = new List<UserPayment>();
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
        public ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>(); // Collection navigation containing dependents
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
        public ICollection<Transaction> Vehicles { get; } = new List<Transaction>();
    }

    public class ParkingSlot
    {
        [Display(Name = "Parking Slot ID")]
        public int ParkingSlotId { get; set; }
        [Display(Name = "Số hiệu")]
        public string SlotNumber { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        public ICollection<Transaction> Transactions { get; } = new List<Transaction>();
    }

    public class Transaction
    {
        public int TransactionId { get; set; }
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

        public ICollection<UserPayment> UserPayments { get; } = new List<UserPayment>();

    } 
    public class UserPayment
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
