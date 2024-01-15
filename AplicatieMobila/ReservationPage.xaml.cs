using AplicatieMobila.Models;

namespace AplicatieMobila;

public partial class ReservationPage : ContentPage
{
	public ReservationPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var reservations = await App.Database.GetReservationsAsync();


        foreach (var reservation in reservations)
        {
            reservation.Client = await App.Database.GetClientByIdAsync((int)reservation.ClientID);
        }

       
        listView.ItemsSource = reservations;
    }

    private void OnCreateReservationClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new CreateReservationPage(new Reservation()));
    }

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        ((ListView)sender).SelectedItem = null;

        if (e.SelectedItem is Reservation selectedReservation)
        {
            await Navigation.PushAsync(new EditReservationPage(selectedReservation));
        }
    }


}
    


