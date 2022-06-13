using At.Mausa.Grasmaster.Domain.Models.Domain;

namespace At.Mausa.Grasmaster.Domain.Models.Domain {
    public class Address : Entity {
        public string Street { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public Address() : base(null) { }

        public void UpdateStreet(string street) {
            if(string.IsNullOrEmpty(street?.Trim()))
                throw new ArgumentException("Street is null or Empty!");
            Street = street;
        }

        public void UpdateCountry(string country) {
            if(string.IsNullOrEmpty(country?.Trim()))
                throw new ArgumentException("Country is null or Empty!");
            Country = country;
        }

        public void UpdateCity(string city) {
            if(string.IsNullOrEmpty(city?.Trim()))
                throw new ArgumentException("City is null or Empty!");
            City = city;
        }
    }
}
