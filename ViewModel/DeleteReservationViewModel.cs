using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    class DeleteReservationViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        Reservation reservationNeedToDelete;

        int id;
        int carId;
        int userId;
        DateTime startDate;
        DateTime endDate;

        string registrationNumber;
        string username;

        public int Id { get => id; set => id = value; }
        public int CarId { get => carId; set => carId = value; }
        public int UserId { get => userId; set => userId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
        public string Username { get => username; set => username = value; }

        public DeleteReservationViewModel(object reservationGet) {
            try {
                reservationNeedToDelete = (Reservation)reservationGet;
                id = reservationNeedToDelete.Id;
                carId = reservationNeedToDelete.CarId;
                userId = reservationNeedToDelete.UserId;
                startDate = reservationNeedToDelete.StartDate;
                endDate = reservationNeedToDelete.EndDate;

                registrationNumber = reservationNeedToDelete.RegistrationNumber;
                username = reservationNeedToDelete.Username;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);

            }
        }

        public void reservationDelete() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdDeleteReservation = new MySqlCommand(MySqlCommands.CmdDeleteReservation, conn);

                cmdDeleteReservation.Parameters.AddWithValue("@id", Id);
                cmdDeleteReservation.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Sikeres törlés!");
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(conn.State != System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
