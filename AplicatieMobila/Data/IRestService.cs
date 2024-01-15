using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieMobila.Models;

namespace AplicatieMobila.Data
{
    public interface IRestService
    {
        Task<List<ShopList>> RefreshDataAsync();
        Task SaveShopListAsync(ShopList item, bool isNewItem);

        Task SaveReservationAsync(Reservation item, bool isNewItem);

        Task DeleteShopListAsync(int id);
        Task<List<Product>> RefreshProductAsync();
        Task<List<Category>> RefreshCategoriesAsync();
        Task<List<Client>> RefreshClientAsync();

        Task<List<Reservation>> RefreshReservationAsync();
        Task<Client> GetClientByIdAsync(int clientId);

        Task DeleteReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);

    }
}
