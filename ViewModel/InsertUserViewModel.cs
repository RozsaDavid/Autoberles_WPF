using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class InsertUserViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        User newUser;

        public InsertUserViewModel(User newUser) {
            this.newUser = newUser;

            var source = Encoding.UTF8.GetBytes(newUser.Password);
            var hashBytes = SHA512.Create().ComputeHash(source);
            newUser.Password = BitConverter.ToString(hashBytes).Replace("-", "");

            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdInsertUser = new MySqlCommand(MySqlCommands.CmdInsertUser, conn);

                cmdInsertUser.Parameters.AddWithValue("@username", newUser.Username);
                cmdInsertUser.Parameters.AddWithValue("@password", newUser.Password);
                cmdInsertUser.Parameters.AddWithValue("@email", newUser.Email);
                cmdInsertUser.Parameters.AddWithValue("@address", newUser.Address);
                cmdInsertUser.Parameters.AddWithValue("@phone", newUser.Phone);
                cmdInsertUser.Parameters.AddWithValue("@role", newUser.Role);
                cmdInsertUser.ExecuteNonQuery();

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
