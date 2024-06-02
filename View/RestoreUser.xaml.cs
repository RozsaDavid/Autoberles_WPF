using Autoberles.Model;
using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for RestoreUser.xaml
    /// </summary>
    public partial class RestoreUser :Window {
        public RestoreUser() {
            InitializeComponent();
            userGridUpload();
        }

        private void userGridUpload() {
            UserViewModel userViewModel = new UserViewModel();

            foreach(User user in userViewModel.Users)
                if(!user.IsActive)
                    dgGridUsers.Items.Add(user);
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e) {
            if(dgGridUsers.SelectedIndex > -1) {
                RestoreUserViewModel restoreUserViewModel = new RestoreUserViewModel((User)dgGridUsers.SelectedItem);
                restoreUserViewModel.userRestore();
                Close();
            } else {
                MessageBox.Show("Nincs kiválasztott felhasználó!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
