namespace NewspaperSystem.Services.MachineData.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MachineDataService : IMachineDataService
    {
        private NewspaperSystemDbContext db;

        public MachineDataService(NewspaperSystemDbContext db)
        {
            this.db = db;
        }

        #region Web Sizes

        public async Task<IEnumerable<WebSizeServiceModel>> AllWebSizesAsync()
        {
            var resuslt = await this.db
                .WebSizes
                .OrderBy(ws => ws.WebWidth)
                .ProjectTo<WebSizeServiceModel>()
                .ToListAsync();

            return resuslt;
        }

        public async Task AddWebSizeAsync(
            string webName,
            int webWidth)
        {
            await this.db.WebSizes.AddAsync(new WebSize()
            {
                WebName = webName,
                WebWidth = webWidth
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<WebSizeServiceModel> GetWebSizeByIdAsync(int id)
        {
            var result = await this.db
                .WebSizes
                .ProjectTo<WebSizeServiceModel>()
                .FirstOrDefaultAsync(ws => ws.Id == id);

            return result;
        }

        public async Task<bool> EditWebSizeAsync(
            int id,
            string webName,
            int webWidth)
        {
            var webSize = await this.db
                .WebSizes
                .FirstOrDefaultAsync(ws => ws.Id == id);

            if (webSize == null)
            {
                return false;
            }

            webSize.WebName = webName;
            webSize.WebWidth = webWidth;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> WebSizeIsUsedAsync(int id)
        {
            return await this.db
                .WebSizes
                .AnyAsync(ws => ws.Id == id && ws.MachineDatas.Any());
        }

        public async Task<bool> DeleteWebSizeAsync(int id)
        {
            var webSise = await this.db
                .WebSizes
                .FirstOrDefaultAsync(ws => ws.Id == id);

            if (webSise == null)
            {
                return false;
            }

            this.db.WebSizes.Remove(webSise);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Machine Data

        public async Task<IEnumerable<MachineDataServiceModel>> AllMachineDatasAsync()
        {
            var result = await this.db
                .MachineDatas
                .OrderBy(md => md.NumberOfPages)
                .ThenBy(md => md.M1NumberOfPages)
                .ThenBy(md => md.M2NumberOfPages)
                .ProjectTo<MachineDataServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddMachineDataAsync(
            byte numberOfPages,
            byte m1NumberOfPages,
            byte m2NumberOfPages,
            int web1Id,
            int web2Id,
            byte productionFactor,
            int baseSpeed)
        {
            await this.db
                .AddAsync(new MachineData()
                {
                    NumberOfPages = numberOfPages,
                    M1NumberOfPages = m1NumberOfPages,
                    M2NumberOfPages = m2NumberOfPages,
                    Web1Id = web1Id,
                    Web2Id = web2Id,
                    ProductionFactor = productionFactor,
                    BaseSpeed = baseSpeed
                });

            await this.db.SaveChangesAsync();
        }

        public async Task<MachineDataServiceModel> GetMachineDataByIdAsync(int id)
        {
            var result = await this.db
                .MachineDatas
                .ProjectTo<MachineDataServiceModel>()
                .FirstOrDefaultAsync(md => md.Id == id);

            return result;
        }

        public async Task<bool> EditMachineDataAsync(
            int id,
            byte numberOfPages,
            byte m1NumberOfPages,
            byte m2NumberOfPages,
            int web1Id,
            int web2Id,
            byte productionFactor,
            int baseSpeed)
        {
            var machineData = await this.db
                .MachineDatas
                .FirstOrDefaultAsync(md => md.Id == id);

            if (machineData == null)
            {
                return false;
            }

            machineData.NumberOfPages = numberOfPages;
            machineData.M1NumberOfPages = m1NumberOfPages;
            machineData.M2NumberOfPages = m2NumberOfPages;
            machineData.Web1Id = web1Id;
            machineData.Web2Id = web2Id;
            machineData.ProductionFactor = productionFactor;
            machineData.BaseSpeed = baseSpeed;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> MachineDataIsUsedAsync(int id)
        {
            return await this.db
                .MachineDatas
                .AnyAsync(md => md.Id == id && md.Components.Any());
        }

        public async Task<bool> DeleteMachineDataAsync(int id)
        {
            var machineData = await this.db
                .MachineDatas
                .FirstOrDefaultAsync(md => md.Id == id);

            if (machineData==null)
            {
                return false;
            }

            this.db.MachineDatas.Remove(machineData);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion
    }
}
