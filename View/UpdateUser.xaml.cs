using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser :Window {
        UpdateUserViewModel updateUserViewModel;
        public UpdateUser(object selectedUser) {
            InitializeComponent();

            cmbRole.Items.Add("User");
            cmbRole.Items.Add("Administrator");

            updateUserViewModel = (UpdateUserViewModel)selectedUser;
            updateUserViewModel.Password = null;
            DataContext = updateUserViewModel;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            if(txbUsername.Text != "" && !txbUsername.Text.Contains(";") &&
                !txbPassword.Text.Contains(";") &&
                txbEmail.Text != "" && !txbEmail.Text.Contains(";") &&
                txbAddress.Text != "" && !txbAddress.Text.Contains(";") &&
                txbPhone.Text != "" && !txbPhone.Text.Contains(";")) {
                updateUserViewModel.userUpdate();
                Close();
            } else {
                MessageBox.Show("Hibás adatokat adott meg!");
            }


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
