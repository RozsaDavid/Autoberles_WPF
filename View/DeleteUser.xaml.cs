using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser :Window {
        DeleteUserViewModel deleteUserViewModel;
        public DeleteUser(object selectedUser) {
            InitializeComponent();

            deleteUserViewModel = (DeleteUserViewModel)selectedUser;
            DataContext = deleteUserViewModel;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            deleteUserViewModel.userDelete();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
