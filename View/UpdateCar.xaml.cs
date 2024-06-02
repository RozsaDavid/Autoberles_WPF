using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for UpdateCar.xaml
    /// </summary>
    public partial class UpdateCar :Window {
        UpdateCarViewModel updateCarViewModel;
        public UpdateCar(object selectedCar) {
            InitializeComponent();

            updateCarViewModel = (UpdateCarViewModel)selectedCar;
            DataContext = updateCarViewModel;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            if(txbRegistrationNumber.Text != "" && !txbRegistrationNumber.Text.Contains(";") &&
                txbBrand.Text != "" && !txbBrand.Text.Contains(";") &&
                txbType.Text != "" && !txbType.Text.Contains(";") &&
                txbYear.Text != "" && !txbYear.Text.Contains(";") &&
                txbPrice.Text != "" && !txbPrice.Text.Contains(";")) {
                updateCarViewModel.carUpdate();
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
