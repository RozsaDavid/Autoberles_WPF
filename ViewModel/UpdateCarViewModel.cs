using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class UpdateCarViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        Car carNeedToUpdate;

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

        public UpdateCarViewModel(object carGet) {
            try {
                carNeedToUpdate = (Car)carGet;

                id = carNeedToUpdate.Id;
                registrationNumber = carNeedToUpdate.RegistrationNumber;
                brand = carNeedToUpdate.Brand;
                type = carNeedToUpdate.Type;
                year = carNeedToUpdate.Year;
                price = carNeedToUpdate.Price;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void carUpdate() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdUpdateCar = new MySqlCommand(MySqlCommands.CmdUpdateCar, conn);

                cmdUpdateCar.Parameters.AddWithValue("@id", id);
                cmdUpdateCar.Parameters.AddWithValue("@registrationNumber", registrationNumber);
                cmdUpdateCar.Parameters.AddWithValue("@brand", brand);
                cmdUpdateCar.Parameters.AddWithValue("@type", type);
                cmdUpdateCar.Parameters.AddWithValue("@year", year);
                cmdUpdateCar.Parameters.AddWithValue("@price", price);
                cmdUpdateCar.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Sikeres módosítás!");
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(conn.State != System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
