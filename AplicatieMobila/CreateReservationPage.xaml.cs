using AplicatieMobila.Models;
namespace AplicatieMobila;

public partial class CreateReservationPage : ContentPage
{
    private Reservation _reservation;

    public CreateReservationPage(Reservation reservation)
	{
        InitializeComponent();
        this._reservation = reservation;

    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var items = await App.Database.GetClientsAsync();
        clientPicker.ItemsSource = (System.Collections.IList)items;
        clientPicker.ItemDisplayBinding = new Binding("FullName");


    }


    private void OnSaveClicked(object sender, EventArgs e)
    {
        _reservation.NumberPeople = int.Parse(numberOfPeopleEntry.Text);
        _reservation.ReservationDate = reservationDatePicker.Date;
        Client selectedClient = clientPicker.SelectedItem as Client;
        _reservation.ClientID = selectedClient?.ID ?? 0;


        App.Database.SaveReservationAsync(_reservation);

        Navigation.PopAsync();
    }


}








