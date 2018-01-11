namespace NewspaperSystem.Services.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IClientService : IService
    {
        // Town
        Task<IEnumerable<TownServiceModel>> AllTownsAsync();

        Task AddTownAsync(string name);

        Task<TownServiceModel> GetTownByIdAsync(int id);

        Task<bool> EditTownAsync(int id, string name);

        Task<bool> DeleteTownAsync(int id);

        Task<bool> TownIsUsedAsync(int id);


        // Client
        Task<IEnumerable<ClientServiceModel>> AllCliensAsync();

        Task AddClientAsync(
            string companyName,
            string vatNumber,
            string address,
            string contactPerson,
            string phone,
            string email,
            bool isActive,
            int townId);

        Task<ClientServiceModel> GetClientByIdAsync(int id);

        Task<bool> EditClientAsync(
            int id,
            string companyName,
            string vatNumber,
            string address,
            string contactPerson,
            string phone,
            string email,
            bool isActive,
            int townId);

        Task<bool> DeleteClientAsync(int id);

        Task<bool> ClientIsUsedAsync(int id);

        // Product

        Task<IEnumerable<ProductServiceModel>> AllProductByClientIdAsync(int clientId);

        Task AddProductAsync(
            string title,
            decimal defaultDiscount,
            bool isActive,
            int clientId);

        Task<ProductServiceModel> GetProductByIdAsync(int id);

        Task<bool> EditProductAsync(
            int id,
            string title,
            decimal defaultDiscount,
            bool isActive,
            int clientId);

        Task<bool> DeleteProductAsync(int id);

        Task<bool> ProductIsUsedAsync(int id);
    }
}