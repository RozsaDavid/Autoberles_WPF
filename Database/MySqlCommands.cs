namespace Autoberles.Database {
    internal class MySqlCommands {
        static string cmdUsers = "SELECT * FROM user;";
        static string cmdCars = "SELECT * FROM car;";
        static string cmdReservations = "SELECT reservation.*, car.registrationNumber, user.Username FROM reservation JOIN car USING(CarID) JOIN user USING(UserID);";

        static string cmdInsertUser = "INSERT INTO user VALUES (null,@username,@password,@email,@address,@phone,@role,1);";
        static string cmdInsertCar = "INSERT INTO car VALUES (null,@registrationNumber,@brand,@type,@year,@price,1);";
        static string cmdInsertReservation = "INSERT INTO reservation VALUES (null,@carId,@userId,@startDate,@endDate);";

        static string cmdUpdateUserWithPassword = "UPDATE user SET username = @username, password = @password, email = @email, address = @address, phone = @phone, role = @role WHERE UserID = @id;";
        static string cmdUpdateUserWithoutPassword = "UPDATE user SET username = @username, email = @email, address = @address, phone = @phone, role = @role WHERE UserID = @id;";
        static string cmdUpdateCar = "UPDATE car SET registrationNumber = @registrationNumber, brand = @brand, type = @type, year = @year, price = @price WHERE CarID = @id;";

        static string cmdDeleteUser = "UPDATE user SET isActive = 0 WHERE UserID = @id;";
        static string cmdDeleteCar = "UPDATE car SET isActive = 0 WHERE CarID = @id;";
        static string cmdDeleteReservation = "DELETE FROM reservation WHERE ReservationID = @id;";

        static string cmdRestoreUser = "UPDATE user SET isActive = 1 WHERE UserID = @id;";
        static string cmdRestoreCar = "UPDATE car SET isActive = 1 WHERE CarID = @id;";

        public static string CmdUsers { get => cmdUsers; set => cmdUsers = value; }
        public static string CmdCars { get => cmdCars; set => cmdCars = value; }
        public static string CmdReservations { get => cmdReservations; set => cmdReservations = value; }
        public static string CmdInsertUser { get => cmdInsertUser; set => cmdInsertUser = value; }
        public static string CmdInsertCar { get => cmdInsertCar; set => cmdInsertCar = value; }
        public static string CmdInsertReservation { get => cmdInsertReservation; set => cmdInsertReservation = value; }
        public static string CmdUpdateUserWithPassword { get => cmdUpdateUserWithPassword; set => cmdUpdateUserWithPassword = value; }
        public static string CmdUpdateUserWithoutPassword { get => cmdUpdateUserWithoutPassword; set => cmdUpdateUserWithoutPassword = value; }
        public static string CmdUpdateCar { get => cmdUpdateCar; set => cmdUpdateCar = value; }
        public static string CmdDeleteUser { get => cmdDeleteUser; set => cmdDeleteUser = value; }
        public static string CmdDeleteCar { get => cmdDeleteCar; set => cmdDeleteCar = value; }
        public static string CmdDeleteReservation { get => cmdDeleteReservation; set => cmdDeleteReservation = value; }
        public static string CmdRestoreUser { get => cmdRestoreUser; set => cmdRestoreUser = value; }
        public static string CmdRestoreCar { get => cmdRestoreCar; set => cmdRestoreCar = value; }
    }
}
