using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for DeleteReservation.xaml
    /// </summary>
    public partial class DeleteReservation :Window {
        DeleteReservationViewModel deleteReservationViewModel;
        public DeleteReservation(object selectedReservation) {
            InitializeComponent();

            deleteReservationViewModel = (DeleteReservationViewModel)selectedReservation;
            DataContext = deleteReservationViewModel;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            deleteReservationViewModel.reservationDelete();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
