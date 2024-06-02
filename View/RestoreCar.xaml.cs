using Autoberles.Model;
using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for RestoreCar.xaml
    /// </summary>
    public partial class RestoreCar :Window {
        public RestoreCar() {
            InitializeComponent();
            carGridUpload();
        }

        private void carGridUpload() {
            CarViewModel carViewModel = new CarViewModel();

            foreach(Car car in carViewModel.Cars)
                if(!car.IsActive)
                    dgGridCars.Items.Add(car);
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e) {
            if(dgGridCars.SelectedIndex > -1) {
                RestoreCarViewModel restoreCarViewModel = new RestoreCarViewModel((Car)dgGridCars.SelectedItem);
                restoreCarViewModel.carRestore();
                Close();
            } else {
                MessageBox.Show("Nincs kiválasztott autó!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
