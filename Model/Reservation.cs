namespace Autoberles.Model {
    internal class Reservation {
        int id;
        int carId;
        int userId;
        DateTime startDate;
        DateTime endDate;

        string registrationNumber;
        string username;

        public Reservation(int id, int carId, int userId, DateTime startDate, DateTime endDate, string registrationNumber, string username) {
            this.Id = id;
            this.CarId = carId;
            this.UserId = userId;
            this.StartDate = startDate;
            this.EndDate = endDate;

            this.RegistrationNumber = registrationNumber;
            this.Username = username;
        }

        public int Id { get => id; set => id = value; }
        public int CarId { get => carId; set => carId = value; }
        public int UserId { get => userId; set => userId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
        public string Username { get => username; set => username = value; }
    }
}
