using Autoberles.Model;
using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for NewCar.xaml
    /// </summary>
    public partial class NewCar :Window {
        List<Car> cars = new List<Car>();
        internal NewCar(List<Car> cars) {
            InitializeComponent();
            this.cars = cars;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            if(txbRegistrationNumber.Text != "" && !txbRegistrationNumber.Text.Contains(";") &&
                txbBrand.Text != "" && !txbBrand.Text.Contains(";") &&
                txbType.Text != "" && !txbType.Text.Contains(";") &&
                txbYear.Text != "" && !txbYear.Text.Contains(";") &&
                txbPrice.Text != "" && !txbPrice.Text.Contains(";")) {

                bool takenRegistrationNumber = false;
                foreach(Car car in cars)
                    if(car.RegistrationNumber == txbRegistrationNumber.Text)
                        takenRegistrationNumber = true;

                if(!takenRegistrationNumber) {
                    try {
                        Car newCar = new Car(-1, txbRegistrationNumber.Text, txbBrand.Text,
                        txbType.Text, int.Parse(txbYear.Text), int.Parse(txbPrice.Text), true);
                        new InsertCarViewModel(newCar);
                        Close();
                    } catch(Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                } else {
                    MessageBox.Show("A megadott rendszám foglalt!");
                }
            } else {
                MessageBox.Show("Hibás adatokat adott meg!");
            }
        }
    }
}
