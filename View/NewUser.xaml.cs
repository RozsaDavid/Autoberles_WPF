using Autoberles.Model;
using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser :Window {
        List<User> users = new List<User>();
        internal NewUser(List<User> users) {
            InitializeComponent();

            cmbRole.Items.Add("User");
            cmbRole.Items.Add("Administrator");
            cmbRole.SelectedIndex = 0;

            this.users = users;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            if(txbUsername.Text != "" && !txbUsername.Text.Contains(";") &&
                txbPassword.Text != "" && !txbPassword.Text.Contains(";") &&
                txbEmail.Text != "" && !txbEmail.Text.Contains(";") &&
                txbAddress.Text != "" && !txbAddress.Text.Contains(";") &&
                txbPhone.Text != "" && !txbPhone.Text.Contains(";")) {

                bool takenUsername = false;
                foreach(User user in users)
                    if(user.Username == txbUsername.Text)
                        takenUsername = true;

                if(!takenUsername) {
                    User newUser = new User(-1, txbUsername.Text, txbPassword.Text
                        , txbEmail.Text, txbAddress.Text, txbPhone.Text, cmbRole.SelectedItem.ToString(), true);

                    new InsertUserViewModel(newUser);
                    Close();
                } else {
                    MessageBox.Show("A felhasználónév már foglalt!");
                }
            } else {
                MessageBox.Show("Hibás adatokat adott meg!");
            }
        }
    }
}
