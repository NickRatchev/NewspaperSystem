namespace NewspaperSystem.Services.MachineData
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
	using Models;

    public interface IMachineDataService : IService
    {
        // Web Sizes
        Task<IEnumerable<WebSizeServiceModel>> AllWebSizesAsync();

        Task AddWebSizeAsync(
            string webName,
            int webWidth);

        Task<WebSizeServiceModel> GetWebSizeByIdAsync(int id);

        Task<bool> EditWebSizeAsync(
            int id,
            string webName,
            int webWidth);

        Task<bool> WebSizeIsUsedAsync(int id);

        Task<bool> DeleteWebSizeAsync(int id);

        // Machine Data
        Task<IEnumerable<MachineDataServiceModel>> AllMachineDatasAsync();

        Task AddMachineDataAsync(
            byte numberOfPages,
            byte m1NumberOfPages,
            byte m2NumberOfPages,
            int web1Id,
            int web2Id,
            byte productionFactor,
            int baseSpeed);

        Task<MachineDataServiceModel> GetMachineDataByIdAsync(int id);

        Task<bool> EditMachineDataAsync(
            int id,
            byte numberOfPages,
            byte m1NumberOfPages,
            byte m2NumberOfPages,
            int web1Id,
            int web2Id,
            byte productionFactor,
            int baseSpeed);

        Task<bool> MachineDataIsUsedAsync(int id);

        Task<bool> DeleteMachineDataAsync(int id);
    }
}
