using Autoberles.Database;
using Autoberles.Model;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Autoberles.ViewModel {
    internal class UserViewModel {
        MySqlConnection conn = new MySqlConnection(MyDbConnection.connection);
        List<User> users = new List<User>();
        internal List<User> Users { get => users; set => users = value; }
        public UserViewModel() {
            try {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdUsers = new MySqlCommand(MySqlCommands.CmdUsers, conn);
                MySqlDataReader dr = cmdUsers.ExecuteReader();
                while(dr.Read()) {
                    int i = dr.GetInt32(0);
                    string un = dr.GetString(1);
                    string pass = "•••••";
                    string em = dr.GetString(3);
                    string a = dr.GetString(4);
                    string p = dr.GetString(5);
                    string r = dr.GetString(6);
                    bool ia = dr.GetBoolean(7);
                    User newUser = new User(i, un, pass, em, a, p, r, ia);
                    Users.Add(newUser);
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
