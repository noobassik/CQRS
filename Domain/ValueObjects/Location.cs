namespace CQRS.Domain.ValueObjects
{
    public record Location
    {
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;

        private Location(string city, string street)
        {
            City = city;
            Street = street;
        }

        public static Location Of(string city, string street) 
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(city);
            ArgumentException.ThrowIfNullOrWhiteSpace(street);

            return new Location(city, street);
        }
    }
}
