using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class InsertCarViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        Car newCar;

        public InsertCarViewModel(Car newCar) {
            this.newCar = newCar;

            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdInsertCar = new MySqlCommand(MySqlCommands.CmdInsertCar, conn);

                cmdInsertCar.Parameters.AddWithValue("@registrationNumber", newCar.RegistrationNumber);
                cmdInsertCar.Parameters.AddWithValue("@brand", newCar.Brand);
                cmdInsertCar.Parameters.AddWithValue("@type", newCar.Type);
                cmdInsertCar.Parameters.AddWithValue("@year", newCar.Year);
                cmdInsertCar.Parameters.AddWithValue("@price", newCar.Price);
                cmdInsertCar.ExecuteNonQuery();

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
