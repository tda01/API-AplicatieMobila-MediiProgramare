using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieMobila.Models;

namespace AplicatieMobila.Data
{
    public class ProductDatabase
    {

        IRestService restService;
        public ProductDatabase(IRestService service)
        {
            restService = service;
        }
        public Task<List<ShopList>> GetShopListsAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return restService.RefreshProductAsync();
        }

        public Task<List<Category>> GetCategoryAsync()
        {
            return restService.RefreshCategoriesAsync();
        }


        public Task SaveShopListAsync(ShopList item, bool isNewItem = true)
        {
            return restService.SaveShopListAsync(item, isNewItem);

        }

        public Task DeleteShopListAsync(ShopList item)
        {
            return restService.DeleteShopListAsync(item.ID);
        }


    }
}
