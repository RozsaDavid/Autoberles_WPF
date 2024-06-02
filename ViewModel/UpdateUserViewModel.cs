using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class UpdateUserViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        User userNeedToUpdate;

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

        public UpdateUserViewModel(object userGet) {
            try {
                userNeedToUpdate = (User)userGet;

                id = userNeedToUpdate.Id;
                username = userNeedToUpdate.Username;
                password = userNeedToUpdate.Password;
                email = userNeedToUpdate.Email;
                address = userNeedToUpdate.Address;
                phone = userNeedToUpdate.Phone;
                role = userNeedToUpdate.Role;

            } catch(Exception ex) {
                MessageBox.Show(ex.Message);

            }
        }

        public void userUpdate() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdUpdateUser;

                if(password != null) {
                    cmdUpdateUser = new MySqlCommand(MySqlCommands.CmdUpdateUserWithPassword, conn);

                    var source = Encoding.UTF8.GetBytes(password);
                    var hashBytes = SHA512.Create().ComputeHash(source);
                    password = BitConverter.ToString(hashBytes).Replace("-", "");

                    cmdUpdateUser.Parameters.AddWithValue("@password", password);
                } else {
                    cmdUpdateUser = new MySqlCommand(MySqlCommands.CmdUpdateUserWithoutPassword, conn);
                }

                cmdUpdateUser.Parameters.AddWithValue("@id", id);
                cmdUpdateUser.Parameters.AddWithValue("@username", username);
                cmdUpdateUser.Parameters.AddWithValue("@email", email);
                cmdUpdateUser.Parameters.AddWithValue("@address", address);
                cmdUpdateUser.Parameters.AddWithValue("@phone", phone);
                cmdUpdateUser.Parameters.AddWithValue("@role", role);
                cmdUpdateUser.ExecuteNonQuery();

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
