using Autoberles.Model;
using Autoberles.View;
using Autoberles.ViewModel;
using System.Windows;

namespace Autoberles {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window {

        public MainWindow() {
            InitializeComponent();
            userGridUpload();
            carGridUpload();
            reservationGridUpload();
        }

        private void userGridUpload() {
            UserViewModel userViewModel = new UserViewModel();
            dgGridUsers.Items.Clear();
            btnRestoreUser.Visibility = Visibility.Hidden;

            foreach(User user in userViewModel.Users)
                if(user.IsActive)
                    dgGridUsers.Items.Add(user);
                else
                    btnRestoreUser.Visibility = Visibility.Visible;
        }

        private void carGridUpload() {
            CarViewModel carViewModel = new CarViewModel();
            dgGridCars.Items.Clear();
            btnRestoreCar.Visibility = Visibility.Hidden;

            foreach(Car car in carViewModel.Cars)
                if(car.IsActive)
                    dgGridCars.Items.Add(car);
                else
                    btnRestoreCar.Visibility = Visibility.Visible;
        }

        private void reservationGridUpload() {
            ReservationViewModel reservationViewModel = new ReservationViewModel();
            dgGridReservations.ItemsSource = reservationViewModel.Reservations;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e) {
            List<User> users = new List<User>();
            users = dgGridUsers.Items.Cast<User>().ToList();
            NewUser newUserWindow = new NewUser(users);
            newUserWindow.Show();
        }

        private void Window_Activated(object sender, EventArgs e) {
            userGridUpload();
            carGridUpload();
            reservationGridUpload();
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e) {
            if(dgGridUsers.SelectedIndex > -1) {
                UpdateUserViewModel updateUserViewModel = new UpdateUserViewModel((User)dgGridUsers.SelectedItem);
                UpdateUser updateUserWindow = new UpdateUser(updateUserViewModel);
                updateUserWindow.Show();
            } else {
                MessageBox.Show("Nincs kiválasztott felhasználó!");
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e) {
            if(dgGridUsers.SelectedIndex > -1) {
                List<Reservation> reservations = new List<Reservation>();
                reservations = dgGridReservations.Items.Cast<Reservation>().ToList();

                bool thereIsActiveReservationWithUser = false;
                foreach(Reservation reservation in reservations)
                    if((DateTime.Compare(reservation.EndDate, DateTime.Now) >= 0) && (((User)dgGridUsers.SelectedItem).Id == reservation.UserId))
                        thereIsActiveReservationWithUser = true;

                if(thereIsActiveReservationWithUser) {
                    MessageBox.Show("Felhasználó aktív foglalás miatt nem törölhető!\nKérem törölje előbb a felhasználóhoz tartozó foglalás(ok)at!");
                } else {
                    DeleteUserViewModel deleteUserViewModel = new DeleteUserViewModel((User)dgGridUsers.SelectedItem);
                    DeleteUser deleteUserWindow = new DeleteUser(deleteUserViewModel);
                    deleteUserWindow.Show();
                }
            } else {
                MessageBox.Show("Nincs kiválasztott felhasználó!");
            }
        }

        private void btnRestoreUser_Click(object sender, RoutedEventArgs e) {
            RestoreUser restoreUserWindow = new RestoreUser(); ;
            restoreUserWindow.Show();
        }

        private void btnDeleteCar_Click(object sender, RoutedEventArgs e) {
            if(dgGridCars.SelectedIndex > -1) {
                List<Reservation> reservations = new List<Reservation>();
                reservations = dgGridReservations.Items.Cast<Reservation>().ToList();

                bool thereIsActiveReservationWithCar = false;
                foreach(Reservation reservation in reservations)
                    if((DateTime.Compare(reservation.EndDate, DateTime.Now) >= 0) && (((Car)dgGridCars.SelectedItem).Id == reservation.CarId))
                        thereIsActiveReservationWithCar = true;

                if(thereIsActiveReservationWithCar) {
                    MessageBox.Show("Az autó aktív foglalás miatt nem törölhető!\nKérem törölje előbb az autóhoz tartozó foglalás(ok)at!");
                } else {
                    DeleteCarViewModel deleteCarViewModel = new DeleteCarViewModel((Car)dgGridCars.SelectedItem);
                    DeleteCar deleteCarWindow = new DeleteCar(deleteCarViewModel);
                    deleteCarWindow.Show();
                }
            } else {
                MessageBox.Show("Nincs kiválasztott autó!");
            }
        }

        private void btnRestoreCar_Click(object sender, RoutedEventArgs e) {
            RestoreCar restoreCarWindow = new RestoreCar(); ;
            restoreCarWindow.Show();
        }

        private void btnNewCar_Click(object sender, RoutedEventArgs e) {
            List<Car> cars = new List<Car>();
            cars = dgGridCars.Items.Cast<Car>().ToList();

            NewCar newCarWindow = new NewCar(cars);
            newCarWindow.Show();
        }

        private void btnUpdateCar_Click(object sender, RoutedEventArgs e) {
            if(dgGridCars.SelectedIndex > -1) {
                UpdateCarViewModel updateCarViewModel = new UpdateCarViewModel((Car)dgGridCars.SelectedItem);
                UpdateCar updateCarWindow = new UpdateCar(updateCarViewModel);
                updateCarWindow.Show();
            } else {
                MessageBox.Show("Nincs kiválasztott autó!");
            }
        }

        private void btnNewReservation_Click(object sender, RoutedEventArgs e) {
            List<Car> cars = new List<Car>();
            cars = dgGridCars.Items.Cast<Car>().ToList();
            List<User> users = new List<User>();
            users = dgGridUsers.Items.Cast<User>().ToList();
            List<Reservation> reservations = new List<Reservation>();
            reservations = dgGridReservations.Items.Cast<Reservation>().ToList();

            NewReservation newReservationWindow = new NewReservation(cars, users, reservations);
            newReservationWindow.Show();
        }

        private void btnDeleteReservation_Click(object sender, RoutedEventArgs e) {
            if(dgGridReservations.SelectedIndex > -1) {
                DeleteReservationViewModel deleteReservationViewModel = new DeleteReservationViewModel((Reservation)dgGridReservations.SelectedItem);
                DeleteReservation deleteReservationWindow = new DeleteReservation(deleteReservationViewModel);
                deleteReservationWindow.Show();
            } else {
                MessageBox.Show("Nincs kiválasztott autó!");
            }
        }
    }
}