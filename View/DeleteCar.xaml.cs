using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for DeleteCar.xaml
    /// </summary>
    public partial class DeleteCar :Window {
        DeleteCarViewModel deleteCarViewModel;
        public DeleteCar(object selectedCar) {
            InitializeComponent();

            deleteCarViewModel = (DeleteCarViewModel)selectedCar;
            DataContext = deleteCarViewModel;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            deleteCarViewModel.carDelete();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
