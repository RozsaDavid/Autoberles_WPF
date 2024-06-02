using Autoberles.Model;
using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles.View {
    /// <summary>
    /// Interaction logic for NewReservation.xaml
    /// </summary>
    public partial class NewReservation :Window {
        int carId;
        int userId;
        List<Car> allCars = new List<Car>();
        List<User> activeUsers = new List<User>();
        List<Reservation> reservations = new List<Reservation>();

        public NewReservation() { }

        internal NewReservation(List<Car> cars, List<User> users, List<Reservation> reservations) {
            InitializeComponent();

            dpStartDate.SelectedDate = DateTime.Now.AddDays(1);
            dpEndDate.SelectedDate = DateTime.Now.AddDays(7);

            activeUsers = users;
            foreach(User user in activeUsers)
                cbUsername.Items.Add(user.Username);
            cbUsername.SelectedIndex = 0;

            allCars = cars;
            foreach(Car car in cars)
                cbRegistrationNumber.Items.Add(car.RegistrationNumber);

            this.reservations = reservations;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e) {
            grReservation.Visibility = Visibility.Hidden;

            if(DateTime.Compare((DateTime)dpStartDate.SelectedDate, (DateTime)dpEndDate.SelectedDate) > 0) {
                MessageBox.Show("Hibás dátumot adott meg!");
                dpStartDate.SelectedDate = DateTime.Now.AddDays(1);
                dpEndDate.SelectedDate = DateTime.Now.AddDays(7);
            } else {
                DateTime choosedStartDate = (DateTime)dpStartDate.SelectedDate;
                DateTime choosedEndDate = (DateTime)dpEndDate.SelectedDate;



                for(int i = 0;i < allCars.Count;i++) {
                    foreach(Reservation reservation in reservations) {
                        if(reservation.CarId == allCars[i].Id) {
                            if(!(
                                    (
                                        (DateTime.Compare(choosedStartDate, reservation.StartDate) > 0)
                                    &&
                                        (DateTime.Compare(choosedStartDate, reservation.EndDate) > 0)
                                    )
                                 ||
                                    (
                                        (DateTime.Compare(choosedStartDate, reservation.StartDate) < 0)
                                    &&
                                        (DateTime.Compare(choosedEndDate, reservation.StartDate) < 0)
                                    )
                               )) {
                                if(cbRegistrationNumber.Items.Contains(allCars[i].RegistrationNumber)) {
                                    cbRegistrationNumber.Items.Remove(allCars[i].RegistrationNumber);
                                }

                            }

                        }
                    }
                }

                if(cbRegistrationNumber.Items.Count == 0)
                    MessageBox.Show("A kiválasztott időtartamban nincs szabad autó!");
                else {
                    cbRegistrationNumber.SelectedIndex = 0;

                    grReservation.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            foreach(Car car in allCars)
                if(car.RegistrationNumber == cbRegistrationNumber.SelectedItem.ToString())
                    carId = car.Id;

            foreach(User user in activeUsers)
                if(user.Username == cbUsername.SelectedItem.ToString())
                    userId = user.Id;

            Reservation newReservation = new Reservation(-1, carId, userId, (DateTime)dpStartDate.SelectedDate, (DateTime)dpEndDate.SelectedDate, null, null);
            new InsertReservationViewModel(newReservation);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void dpEndDate_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            grReservation.Visibility = Visibility.Hidden;
        }

        private void dpEndDate_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
            grReservation.Visibility = Visibility.Hidden;
        }

        private void dpStartDate_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            grReservation.Visibility = Visibility.Hidden;
        }

        private void dpStartDate_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
            grReservation.Visibility = Visibility.Hidden;
        }
    }
}
