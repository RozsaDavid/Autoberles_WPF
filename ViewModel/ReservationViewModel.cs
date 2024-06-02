using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    class ReservationViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        List<Reservation> reservations = new List<Reservation>();
        internal List<Reservation> Reservations { get => reservations; set => reservations = value; }


        public ReservationViewModel() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdReservations = new MySqlCommand(MySqlCommands.CmdReservations, conn);
                MySqlDataReader dr = cmdReservations.ExecuteReader();
                while(dr.Read()) {
                    int i = dr.GetInt32(0);
                    int ci = dr.GetInt32(1);
                    int ui = dr.GetInt32(2);
                    DateTime sd = dr.GetDateTime(3);
                    DateTime ed = dr.GetDateTime(4);
                    string rn = dr.GetString(5);
                    string un = dr.GetString(6);
                    Reservation newReservation = new Reservation(i, ci, ui, sd, ed, rn, un);
                    reservations.Add(newReservation);
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
