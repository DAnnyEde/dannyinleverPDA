
using System;
using BlazorProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BlazorProject.Data.Accommodation", b =>
                {
                    b.Property<int>("AccommodationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("accommodationID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AccommodationID"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageURL")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imageURL");

                    b.Property<int>("LocationID")
                        .HasColumnType("int")
                        .HasColumnName("locationID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.HasKey("AccommodationID");

                    b.HasIndex("LocationID");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("BlazorProject.Data.AccommodationProperty", b =>
                {
                    b.Property<int>("AccommodationID")
                        .HasColumnType("int")
                        .HasColumnName("accommodationID");

                    b.Property<int>("PropertyID")
                        .HasColumnType("int")
                        .HasColumnName("propertyID");

                    b.Property<string>("Value")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("value");

                    b.HasKey("AccommodationID", "PropertyID");

                    b.HasIndex("PropertyID");

                    b.ToTable("AccommodationProperties");
                });

            modelBuilder.Entity("BlazorProject.Data.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bookingID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookingID"));

                    b.Property<int>("AccommodationID")
                        .HasColumnType("int")
                        .HasColumnName("accommodationID");

                    b.Property<DateTime?>("ArrivalDate")
                        .HasColumnType("date")
                        .HasColumnName("arrivalDate");

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("date")
                        .HasColumnName("bookingDate");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("date")
                        .HasColumnName("departureDate");

                    b.Property<int?>("NumberOfGuests")
                        .HasColumnType("int")
                        .HasColumnName("numberOfGuests");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("totalPrice");

                    b.HasKey("BookingID");

                    b.HasIndex("AccommodationID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BlazorProject.Data.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("char(50)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastName");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phoneNumber");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BlazorProject.Data.CustomerWish", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    b.Property<int>("WishID")
                        .HasColumnType("int")
                        .HasColumnName("wishID");

                    b.Property<int>("PropertyID")
                        .HasColumnType("int")
                        .HasColumnName("propertyID");

                    b.Property<string>("Value")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("value");

                    b.HasKey("CustomerID", "WishID");

                    b.HasIndex("PropertyID");

                    b.HasIndex("WishID")
                        .IsUnique();

                    b.ToTable("CustomerWishes");
                });

            modelBuilder.Entity("BlazorProject.Data.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("locationID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("City")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("country");

                    b.Property<string>("Province")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("province");

                    b.HasKey("LocationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("BlazorProject.Data.Property", b =>
                {
                    b.Property<int>("PropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("propertyID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PropertyID"));

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("PropertyID");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("BlazorProject.Data.Accommodation", b =>
                {
                    b.HasOne("BlazorProject.Data.Location", "Location")
                        .WithMany("Accommodations")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("BlazorProject.Data.AccommodationProperty", b =>
                {
                    b.HasOne("BlazorProject.Data.Accommodation", "Accommodation")
                        .WithMany("AccommodationProperties")
                        .HasForeignKey("AccommodationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorProject.Data.Property", "Property")
                        .WithMany("AccommodationProperties")
                        .HasForeignKey("PropertyID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("BlazorProject.Data.Booking", b =>
                {
                    b.HasOne("BlazorProject.Data.Accommodation", "Accommodation")
                        .WithMany("Bookings")
                        .HasForeignKey("AccommodationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlazorProject.Data.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BlazorProject.Data.CustomerWish", b =>
                {
                    b.HasOne("BlazorProject.Data.Customer", "Customer")
                        .WithMany("CustomerWishes")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorProject.Data.Property", "Property")
                        .WithMany("CustomerWishes")
                        .HasForeignKey("PropertyID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("BlazorProject.Data.Accommodation", b =>
                {
                    b.Navigation("AccommodationProperties");

                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BlazorProject.Data.Customer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("CustomerWishes");
                });

            modelBuilder.Entity("BlazorProject.Data.Location", b =>
                {
                    b.Navigation("Accommodations");
                });

            modelBuilder.Entity("BlazorProject.Data.Property", b =>
                {
                    b.Navigation("AccommodationProperties");

                    b.Navigation("CustomerWishes");
                });
#pragma warning restore 612, 618
        }
    }
}
