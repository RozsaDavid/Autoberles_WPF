using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class RestoreUserViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        User userNeedToRestore;

        int id;
        string username;
        string role;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Role { get => role; set => role = value; }

        public RestoreUserViewModel(object userGet) {
            try {
                userNeedToRestore = (User)userGet;

                id = userNeedToRestore.Id;
                username = userNeedToRestore.Username;
                role = userNeedToRestore.Role;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void userRestore() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdRestoreUser = new MySqlCommand(MySqlCommands.CmdRestoreUser, conn);

                cmdRestoreUser.Parameters.AddWithValue("@id", id);
                cmdRestoreUser.ExecuteNonQuery();

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
