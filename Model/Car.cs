namespace Autoberles.Model {
    internal class Car {
        int id;
        string registrationNumber;
        string brand;
        string type;
        int year;
        int price;
        bool isActive;

        public Car(int id, string registrationNumber, string brand, string type, int year, int price, bool isActive) {
            this.Id = id;
            this.RegistrationNumber = registrationNumber;
            this.Brand = brand;
            this.Type = type;
            this.Year = year;
            this.Price = price;
            this.IsActive = isActive;
        }

        public int Id { get => id; set => id = value; }
        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Type { get => type; set => type = value; }
        public int Year { get => year; set => year = value; }
        public int Price { get => price; set => price = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}
