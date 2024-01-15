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

        public Task<List<Client>> GetClientsAsync()
        {
            return restService.RefreshClientAsync();
        }

        public Task<List<Reservation>> GetReservationsAsync()
        {
            return restService.RefreshReservationAsync();
        }

        public Task<Client> GetClientByIdAsync(int clientId)
        {
            return restService.GetClientByIdAsync(clientId);
        }



        public Task SaveShopListAsync(ShopList item, bool isNewItem = true)
        {
            return restService.SaveShopListAsync(item, isNewItem);

        }

        public Task DeleteShopListAsync(ShopList item)
        {
            return restService.DeleteShopListAsync(item.ID);
        }



        public Task DeleteReservationAsync(Reservation item)
        {
            return restService.DeleteReservationAsync(item);
        }

        public Task UpdateReservationAsync(Reservation item)
        {
            return restService.UpdateReservationAsync(item);
        }

        public Task SaveReservationAsync(Reservation item, bool isNewItem = true)
        {
            return restService.SaveReservationAsync(item, isNewItem);
        }


    }
}
