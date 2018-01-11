namespace NewspaperSystem.Services.Clients.Implemetations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ClientService : IClientService
    {
        private readonly NewspaperSystemDbContext db;

        public ClientService(NewspaperSystemDbContext db)
        {
            this.db = db;
        }

        #region Towns

        public async Task<IEnumerable<TownServiceModel>> AllTownsAsync()
        {
            var result = await this.db
                .Towns
                .OrderBy(t => t.Name)
                .ProjectTo<TownServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddTownAsync(string name)
        {
            await this.db.Towns
                .AddAsync(new Town()
                {
                    Name = name
                });

            await this.db.SaveChangesAsync();
        }

        public async Task<TownServiceModel> GetTownByIdAsync(int id)
        {
            var result = await this.db.Towns
                .ProjectTo<TownServiceModel>()
                .FirstOrDefaultAsync(t => t.Id == id);

            return result;
        }

        public async Task<bool> EditTownAsync(int id, string name)
        {
            var town = await this.db.Towns
                .FirstOrDefaultAsync(t => t.Id == id);

            if (town == null)
            {
                return false;
            }

            town.Name = name;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTownAsync(int id)
        {
            var town = await this.db.Towns
                .FirstOrDefaultAsync(t => t.Id == id);

            if (town == null)
            {
                return false;
            }

            this.db.Towns.Remove(town);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> TownIsUsedAsync(int id)
        {
            var result = await this.db.Towns
                .AnyAsync(t => t.Id == id && t.Clients.Any());

            return result;
        }

        #endregion

        #region Clients

        public async Task<IEnumerable<ClientServiceModel>> AllCliensAsync()
        {
            var result = await this.db
                .Clients
                .OrderBy(t => t.CompanyName)
                .ProjectTo<ClientServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddClientAsync(
            string companyName,
            string vatNumber,
            string address,
            string contactPerson,
            string phone,
            string email,
            bool isActive,
            int townId)
        {
            await this.db.Clients
                .AddAsync(new Client()
                {
                    CompanyName = companyName,
                    VatNumber = vatNumber,
                    Address = address,
                    ContactPerson = contactPerson,
                    Phone = phone,
                    Email = email,
                    IsActive = isActive,
                    TownId = townId
                });

            await this.db.SaveChangesAsync();
        }

        public async Task<ClientServiceModel> GetClientByIdAsync(int id)
        {
            var result = await this.db.Clients
                .ProjectTo<ClientServiceModel>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<bool> EditClientAsync(
            int id,
            string companyName,
            string vatNumber,
            string address,
            string contactPerson,
            string phone,
            string email,
            bool isActive,
            int townId)
        {
            var client = await this.db.Clients
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return false;
            }

            client.CompanyName = companyName;
            client.VatNumber = vatNumber;
            client.Address = address;
            client.ContactPerson = contactPerson;
            client.Phone = phone;
            client.Email = email;
            client.IsActive = isActive;
            client.TownId = townId;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await this.db.Clients
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return false;
            }

            this.db.Clients.Remove(client);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ClientIsUsedAsync(int id)
        {
            var result = await this.db.Clients
                .AnyAsync(c => c.Id == id && (c.Products.Any() || c.Orders.Any()));

            return result;
        }

        #endregion

        #region Products

        public async Task<IEnumerable<ProductServiceModel>> AllProductByClientIdAsync(int clientId)
        {
            var result = await this.db
                .Products
                .Where(p => p.ClientId == clientId)
                .OrderBy(p => p.Title)
                .ProjectTo<ProductServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddProductAsync(
            string title
            , decimal defaultDiscount
            , bool isActive
            , int clientId)
        {
            await this.db.Products.AddAsync(new Product()
            {
                Title = title,
                DefaultDiscount = defaultDiscount,
                IsActive = isActive,
                ClientId = clientId
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<ProductServiceModel> GetProductByIdAsync(int id)
        {
            var result = await this.db.Products
                .ProjectTo<ProductServiceModel>()
                .FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public async Task<bool> EditProductAsync(
            int id,
            string title,
            decimal defaultDiscount,
            bool isActive,
            int clientId)
        {
            var product = await this.db.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            product.Title = title;
            product.DefaultDiscount = defaultDiscount;
            product.IsActive = isActive;
            product.ClientId = clientId;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await this.db.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            this.db.Products.Remove(product);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ProductIsUsedAsync(int id)
        {
            var result = await this.db.Products
                .AnyAsync(p => p.Id == id && p.Orders.Any());

            return result;
        }

        #endregion

    }
}
