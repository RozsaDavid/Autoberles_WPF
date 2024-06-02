using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    class InsertReservationViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        Reservation newReservation;

        public InsertReservationViewModel(Reservation newReservation) {
            this.newReservation = newReservation;

            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdInsertReservation = new MySqlCommand(MySqlCommands.CmdInsertReservation, conn);

                cmdInsertReservation.Parameters.AddWithValue("@carId", newReservation.CarId);
                cmdInsertReservation.Parameters.AddWithValue("@userId", newReservation.UserId);
                cmdInsertReservation.Parameters.AddWithValue("@startDate", newReservation.StartDate);
                cmdInsertReservation.Parameters.AddWithValue("@endDate", newReservation.EndDate);
                cmdInsertReservation.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Sikeres mentés!");
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(conn.State != System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
