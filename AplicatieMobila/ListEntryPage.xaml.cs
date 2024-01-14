using AplicatieMobila.Models;

namespace AplicatieMobila;

public partial class ListEntryPage : ContentPage
{
    public ListEntryPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }


    void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Handle item selection if needed.
    }


}