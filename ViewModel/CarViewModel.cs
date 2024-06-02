using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class CarViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        List<Car> cars = new List<Car>();
        internal List<Car> Cars { get => cars; set => cars = value; }
        public CarViewModel() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdCars = new MySqlCommand(MySqlCommands.CmdCars, conn);
                MySqlDataReader dr = cmdCars.ExecuteReader();
                while(dr.Read()) {
                    int i = dr.GetInt32(0);
                    string rn = dr.GetString(1);
                    string b = dr.GetString(2);
                    string t = dr.GetString(3);
                    int y = dr.GetInt32(4);
                    int p = dr.GetInt32(5);
                    bool ia = dr.GetBoolean(6);
                    Car newCar = new Car(i, rn, b, t, y, p, ia);
                    Cars.Add(newCar);
                }

                conn.Close();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(conn.State != System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
