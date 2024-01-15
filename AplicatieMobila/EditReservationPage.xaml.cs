using AplicatieMobila.Models;

namespace AplicatieMobila
{
    public partial class EditReservationPage : ContentPage
    {
        private Reservation _reservation;

        public EditReservationPage(Reservation reservation)
        {
            InitializeComponent();
            _reservation = reservation;
            numberOfPeopleEntry.Text = _reservation.NumberPeople.ToString();
            reservationDatePicker.Date = _reservation.ReservationDate;
        }





        private void OnSaveClicked(object sender, EventArgs e)
        {
            _reservation.NumberPeople = int.Parse(numberOfPeopleEntry.Text);
            _reservation.ReservationDate = reservationDatePicker.Date;
            Client selectedClient = clientPicker.SelectedItem as Client;
            _reservation.ClientID = selectedClient?.ID ?? 0;


            App.Database.UpdateReservationAsync(_reservation);

            Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
  
            await App.Database.DeleteReservationAsync(_reservation);
            await Navigation.PopAsync();

        }
    }
}
