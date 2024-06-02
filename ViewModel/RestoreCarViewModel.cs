using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class RestoreCarViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        Car carNeedToRestore;

        int id;
        string registrationNumber;
        string brand;

        public int Id { get => id; set => id = value; }
        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
        public string Brand { get => brand; set => brand = value; }

        public RestoreCarViewModel(object carGet) {
            try {
                carNeedToRestore = (Car)carGet;

                id = carNeedToRestore.Id;
                registrationNumber = carNeedToRestore.RegistrationNumber;
                brand = carNeedToRestore.Brand;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void carRestore() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdRestoreCar = new MySqlCommand(MySqlCommands.CmdRestoreCar, conn);

                cmdRestoreCar.Parameters.AddWithValue("@id", id);
                cmdRestoreCar.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Sikeres visszaállítás!");
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(conn.State != System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
