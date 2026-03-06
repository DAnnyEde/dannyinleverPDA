namespace BlazorProject.Data
{
    public static class Seed
    {
        public static List<Customer> Customers = new()
        {
            new Customer
            {
                CustomerID = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123-456-7890"
            },
            new Customer
            {
                CustomerID = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "098-765-4321"
            }
        };

        public static List<Location> Locations = new()
        {
            new Location
            {
                LocationID = 1,
                City = "New York",
                Province = "NY",
                Country = "USA"
            },
            new Location
            {
                LocationID = 2,
                City = "Los Angeles",
                Province = "CA",
                Country = "USA"
            }
        };

        public static List<Accommodation> Accommodations = new()
        {
            new Accommodation
            {
                AccommodationID = 1,
                LocationID = 1,
                Name = "Luxury Suite",
                Description = "A luxurious suite with amazing views.",
                Price = 250.00m,
                ImageURL = "luxury_suite.jpg"
            },
            new Accommodation
            {
                AccommodationID = 2,
                LocationID = 2,
                Name = "Beachfront Villa",
                Description = "A beautiful villa with a view of the ocean.",
                Price = 450.00m,
                ImageURL = "beachfront_villa.jpg"
            }
        };

        public static List<Property> Properties = new()
        {
            new Property { PropertyID = 1, Name = "Size" },
            new Property { PropertyID = 2, Name = "Amenities" }
        };

        public static List<AccommodationProperty> AccommodationProperties = new()
        {
            new AccommodationProperty { AccommodationID = 1, PropertyID = 1, Value = "100 m²" },
            new AccommodationProperty { AccommodationID = 1, PropertyID = 2, Value = "Pool, Gym" },
            new AccommodationProperty { AccommodationID = 2, PropertyID = 1, Value = "200 m²" },
            new AccommodationProperty { AccommodationID = 2, PropertyID = 2, Value = "Private Beach, Hot Tub" }
        };

        public static List<CustomerWish> CustomerWishes = new()
        {
            new CustomerWish { CustomerID = 1, WishID = 1, PropertyID = 1, Value = "50 m² or more" },
            new CustomerWish { CustomerID = 2, WishID = 2, PropertyID = 2, Value = "Pool and Ocean View" }
        };

        public static List<Booking> Bookings = new()
        {
            new Booking
            {
                BookingID = 1,
                CustomerID = 1,
                AccommodationID = 1,
                BookingDate = new DateTime(2023, 12, 1),
                ArrivalDate = new DateTime(2023, 12, 10),
                DepartureDate = new DateTime(2023, 12, 15),
                NumberOfGuests = 2,
                TotalPrice = 250.00m * 5
            },
            new Booking
            {
                BookingID = 2,
                CustomerID = 2,
                AccommodationID = 2,
                BookingDate = new DateTime(2023, 11, 15),
                ArrivalDate = new DateTime(2023, 11, 20),
                DepartureDate = new DateTime(2023, 11, 25),
                NumberOfGuests = 4,
                TotalPrice = 450.00m * 5
            }
        };
    }
}
