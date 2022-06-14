namespace At.Mausa.Grasmaster.Domain.Models {

    [System.Serializable]
    public struct Address {
        public Address() {
        }

        public string Street { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

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

        public override string ToString() {
            return $"{Street},{Country},{City}";
        }
        
        public static Address ConvertAddress(string str) {
            string[] c = str.Split(",");
            if(c.Length != 3)
                return new Address();

            return new Address() {
                Street  = c[0],
                Country = c[1],
                City = c[2]
            };
        }

    }
}
