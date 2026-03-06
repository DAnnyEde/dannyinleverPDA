using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Accommodation> Accommodations { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<AccommodationProperty> AccommodationProperties { get; set; }
    public DbSet<CustomerWish> CustomerWishes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    
        modelBuilder.Entity<AccommodationProperty>()
            .HasKey(ap => new { ap.AccommodationID, ap.PropertyID });

    
        modelBuilder.Entity<CustomerWish>()
            .HasKey(cw => new { cw.CustomerID, cw.WishID });

        modelBuilder.Entity<CustomerWish>()
            .HasIndex(cw => cw.WishID)
            .IsUnique();

  
        modelBuilder.Entity<Accommodation>()
            .HasOne(a => a.Location)
            .WithMany(l => l.Accommodations)
            .HasForeignKey(a => a.LocationID)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Customer)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.CustomerID)
            .OnDelete(DeleteBehavior.Restrict);

     
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Accommodation)
            .WithMany(a => a.Bookings)
            .HasForeignKey(b => b.AccommodationID)
            .OnDelete(DeleteBehavior.Restrict);

      
        modelBuilder.Entity<AccommodationProperty>()
            .HasOne(ap => ap.Accommodation)
            .WithMany(a => a.AccommodationProperties)
            .HasForeignKey(ap => ap.AccommodationID)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<AccommodationProperty>()
            .HasOne(ap => ap.Property)
            .WithMany(p => p.AccommodationProperties)
            .HasForeignKey(ap => ap.PropertyID)
            .OnDelete(DeleteBehavior.Restrict);

       
        modelBuilder.Entity<CustomerWish>()
            .HasOne(cw => cw.Customer)
            .WithMany(c => c.CustomerWishes)
            .HasForeignKey(cw => cw.CustomerID)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<CustomerWish>()
            .HasOne(cw => cw.Property)
            .WithMany(p => p.CustomerWishes)
            .HasForeignKey(cw => cw.PropertyID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// Location

[Table("Location")]
public class Location
{
    [Key]
    [Column("locationID")]
    public int LocationID { get; set; }

    [Column("city", TypeName = "varchar(100)")]
    public string? City { get; set; }

    [Column("province", TypeName = "varchar(100)")]
    public string? Province { get; set; }

    [Column("country", TypeName = "varchar(100)")]
    public string? Country { get; set; }

    public ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
}

// Customers

[Table("Customers")]
public class Customer
{
    [Key]
    [Column("customerID")]
    public int CustomerID { get; set; }

    [Required]
    [Column("firstName", TypeName = "char(50)")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Column("lastName", TypeName = "varchar(50)")]
    public string LastName { get; set; } = string.Empty;

    [Column("email", TypeName = "varchar(100)")]
    public string? Email { get; set; }

    [Column("phoneNumber", TypeName = "varchar(20)")]
    public string? PhoneNumber { get; set; }

    public ICollection<CustomerWish> CustomerWishes { get; set; } = new List<CustomerWish>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
// Properties 

[Table("Properties")]
public class Property
{
    [Key]
    [Column("propertyID")]
    public int PropertyID { get; set; }

    [Column("name", TypeName = "varchar(50)")]
    public string? Name { get; set; }

    public ICollection<AccommodationProperty> AccommodationProperties { get; set; } = new List<AccommodationProperty>();
    public ICollection<CustomerWish> CustomerWishes { get; set; } = new List<CustomerWish>();
}
// Accommodations

[Table("Accommodations")]
public class Accommodation
{
    [Key]
    [Column("accommodationID")]
    public int AccommodationID { get; set; }

    [Column("locationID")]
    public int LocationID { get; set; }

    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; set; } = string.Empty;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("price", TypeName = "decimal(10,2)")]
    public decimal? Price { get; set; }

    [Column("imageURL", TypeName = "varchar(255)")]
    public string? ImageURL { get; set; }

    public Location Location { get; set; } = null!;
    public ICollection<AccommodationProperty> AccommodationProperties { get; set; } = new List<AccommodationProperty>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

// Bookings

[Table("Bookings")]
public class Booking
{
    [Key]
    [Column("bookingID")]
    public int BookingID { get; set; }

    [Column("customerID")]
    public int CustomerID { get; set; }

    [Column("accommodationID")]
    public int AccommodationID { get; set; }

    [Column("bookingDate", TypeName = "date")]
    public DateTime? BookingDate { get; set; }

    [Column("arrivalDate", TypeName = "date")]
    public DateTime? ArrivalDate { get; set; }

    [Column("departureDate", TypeName = "date")]
    public DateTime? DepartureDate { get; set; }

    [Column("numberOfGuests")]
    public int? NumberOfGuests { get; set; }

    [Column("totalPrice", TypeName = "decimal(10,2)")]
    public decimal? TotalPrice { get; set; }

    public Customer Customer { get; set; } = null!;
    public Accommodation Accommodation { get; set; } = null!;
}

// =========================================================
// AccommodationProperties (junction table)
// =========================================================
[Table("AccommodationProperties")]
public class AccommodationProperty
{
    [Column("accommodationID")]
    public int AccommodationID { get; set; }

    [Column("propertyID")]
    public int PropertyID { get; set; }

    [Column("value", TypeName = "varchar(50)")]
    public string? Value { get; set; }

    public Accommodation Accommodation { get; set; } = null!;
    public Property Property { get; set; } = null!;
}

// CustomerWishes
[Table("CustomerWishes")]
public class CustomerWish
{
    [Column("customerID")]
    public int CustomerID { get; set; }

    [Column("wishID")]
    public int WishID { get; set; }

    [Column("propertyID")]
    public int PropertyID { get; set; }

    [Column("value", TypeName = "varchar(50)")]
    public string? Value { get; set; }

    public Customer Customer { get; set; } = null!;
    public Property Property { get; set; } = null!;
}
