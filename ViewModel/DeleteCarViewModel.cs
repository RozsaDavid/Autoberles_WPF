using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class DeleteCarViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        Car carNeedToDelete;

        int id;
        string registrationNumber;
        string brand;
        string type;
        int year;
        int price;

        public int Id { get => id; set => id = value; }
        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Type { get => type; set => type = value; }
        public int Year { get => year; set => year = value; }
        public int Price { get => price; set => price = value; }

        public DeleteCarViewModel(object carGet) {
            try {
                carNeedToDelete = (Car)carGet;

                id = carNeedToDelete.Id;
                registrationNumber = carNeedToDelete.RegistrationNumber;
                brand = carNeedToDelete.Brand;
                type = carNeedToDelete.Type;
                year = carNeedToDelete.Year;
                price = carNeedToDelete.Price;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void carDelete() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdDeleteCar = new MySqlCommand(MySqlCommands.CmdDeleteCar, conn);

                cmdDeleteCar.Parameters.AddWithValue("@id", id);
                cmdDeleteCar.ExecuteNonQuery();

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
