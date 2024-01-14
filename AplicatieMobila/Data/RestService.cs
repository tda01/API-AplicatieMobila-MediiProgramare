using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieMobila.Models;
using Newtonsoft.Json;

namespace AplicatieMobila.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        string BaseUrl = "https://192.168.100.27:45455/api/";

        
        string RestEndpoint = "{0}";

        public List<ShopList> Items { get; private set; }
        public List<Product> Products { get; private set; }
        public List<Category> Categories { get; private set; }


        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => true;
            client = new HttpClient(httpClientHandler);
        }

        
        private Uri BuildUri(string endpoint)
        {
            string fullUrl = $"{BaseUrl}{endpoint}";
            return new Uri(fullUrl);
        }

        public async Task<List<ShopList>> RefreshDataAsync()
        {
            Items = new List<ShopList>();
            Uri uri = BuildUri(string.Format(RestEndpoint, "products"));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<ShopList>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Items;
        }

        public async Task<List<Product>> RefreshProductAsync()
        {
            Products = new List<Product>();
            Uri uri = BuildUri(string.Format(RestEndpoint, "products"));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<List<Product>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Products;
        }


        public async Task<List<Category>> RefreshCategoriesAsync()
        {
            Categories = new List<Category>();
            Uri uri = BuildUri(string.Format(RestEndpoint, "categories"));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Categories = JsonConvert.DeserializeObject<List<Category>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Categories;
        }










        public async Task SaveShopListAsync(ShopList item, bool isNewItem = true)
        {
            Uri uri = BuildUri(string.Format(RestEndpoint, "products"));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tTodoItem successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteShopListAsync(int id)
        {
            Uri uri = BuildUri(string.Format(RestEndpoint, $"products/{id}"));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tTodoItem successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }

}
