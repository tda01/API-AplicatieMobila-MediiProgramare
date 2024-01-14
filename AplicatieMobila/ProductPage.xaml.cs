namespace AplicatieMobila;

public partial class ProductPage : ContentPage
{
    private int categoryId;
    private string categoryName;


    public ProductPage(int categoryId, string categoryName)
	{
		InitializeComponent();

		this.categoryId = categoryId;
        this.categoryName = categoryName;

        Title = categoryName;


        LoadProducts();
	}

    private async void LoadProducts()
    {
        try
        {
     
            var allProducts = await App.Database.GetProductsAsync();

            var productsForCategory = allProducts.Where(p => p.CategoryID == categoryId).ToList();

            productListView.ItemsSource = productsForCategory;

            if (!productsForCategory.Any())
            {
               
                DisplayAlert("Alert", "No products found for this category.", "OK");
                await Navigation.PopAsync();

            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error loading products: {ex.Message}");
        }
    }



}