using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class DeleteUserViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        User userNeedToDelete;

        int id;
        string username;
        string password;
        string email;
        string address;
        string phone;
        string role;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Role { get => role; set => role = value; }

        public DeleteUserViewModel(object userGet) {
            try {
                userNeedToDelete = (User)userGet;

                id = userNeedToDelete.Id;
                username = userNeedToDelete.Username;
                password = userNeedToDelete.Password;
                email = userNeedToDelete.Email;
                address = userNeedToDelete.Address;
                phone = userNeedToDelete.Phone;
                role = userNeedToDelete.Role;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void userDelete() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdDeleteUser = new MySqlCommand(MySqlCommands.CmdDeleteUser, conn);

                cmdDeleteUser.Parameters.AddWithValue("@id", id);
                cmdDeleteUser.ExecuteNonQuery();

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
