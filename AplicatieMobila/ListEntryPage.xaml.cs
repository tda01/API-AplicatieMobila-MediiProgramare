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
        listView.ItemsSource = await App.Database.GetCategoryAsync();
    }


    void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        // Obține categoria selectată
        var selectedCategory = (Category)e.SelectedItem;


        listView.SelectedItem = null;


        Navigation.PushAsync(new ProductPage(selectedCategory.ID, selectedCategory.CategoryName));
    }


}