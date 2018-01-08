namespace NewspaperSystem.Services.Materials
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Models;

    public interface IMaterialService
    {
        // Paper Type
        Task<IEnumerable<PaperTypeServiceModel>> AllPaperTypesAsync();

        Task AddPaperTypeAsync(
            string name,
            decimal grammage,
            bool isActive);

        Task<PaperTypeServiceModel> GetPaperTypeByIdAsync(int id);

        Task<bool> EditPaperTypeAsync(
            int id,
            string name,
            decimal grammage,
            bool isActive);

        Task<bool> PaperTypeIsUsedAsync(int id);

        Task<bool> DeletePaperTypeAsync(int id);

        // Paper
        Task<IEnumerable<PaperServiceModel>> AllPapersAsync();

        Task AddPaperAsync(
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin);

        Task<PaperServiceModel> GetPaperByIdAsync(int id);

        Task<bool> EditPaperAsync(
            int id,
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeletePaperAsync(int id);


        // Color Ink
        Task<IEnumerable<BaseMaterialServiceModel>> AllColorInksAsync();

        Task AddColorInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetColorInkByIdAsync(int id);

        Task<bool> EditColorInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeleteColorInkAsync(int id);

        // Black Ink
        Task<IEnumerable<BaseMaterialServiceModel>> AllBlackInksAsync();

        Task AddBlackInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetBlackInkByIdAsync(int id);

        Task<bool> EditBlackInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeleteBlackInkAsync(int id);

        // Plate
        Task<IEnumerable<BaseMaterialServiceModel>> AllPlatesAsync();

        Task AddPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetPlateByIdAsync(int id);

        Task<bool> EditPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeletePlateAsync(int id);

        // BlindPlate
        Task<IEnumerable<BaseMaterialServiceModel>> AllBlindPlatesAsync();

        Task AddBlindPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetBlindPlateByIdAsync(int id);

        Task<bool> EditBlindPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeleteBlindPlateAsync(int id);

        // PlateDeveloper
        Task<IEnumerable<BaseMaterialServiceModel>> AllPlateDevelopersAsync();

        Task AddPlateDeveloperAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetPlateDeveloperByIdAsync(int id);

        Task<bool> EditPlateDeveloperAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeletePlateDeveloperAsync(int id);

        // Wischwasser
        Task<IEnumerable<BaseMaterialServiceModel>> AllWischwassersAsync();

        Task AddWischwasserAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetWischwasserByIdAsync(int id);

        Task<bool> EditWischwasserAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeleteWischwasserAsync(int id);

        // Foil
        Task<IEnumerable<BaseMaterialServiceModel>> AllFoilsAsync();

        Task AddFoilAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetFoilByIdAsync(int id);

        Task<bool> EditFoilAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeleteFoilAsync(int id);

        // Tape
        Task<IEnumerable<BaseMaterialServiceModel>> AllTapesAsync();

        Task AddTapeAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetTapeByIdAsync(int id);

        Task<bool> EditTapeAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<bool> DeleteTapeAsync(int id);

        // Service Prices
        Task<IEnumerable<ServicePriceServiceModel>> AllServicesAsync();

        Task AddServiceAsync(
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing);

        Task<ServicePriceServiceModel> GetServiceByIdAsync(int id);

        Task<bool> EditServiceAsync(
            int id,
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing);

        Task<bool> DeleteServiceAsync(int id);

        // Material Consumptions
        Task<IEnumerable<MaterialConsumptionServiceModel>> AllConsumptionsAsync();

        Task AddConsumptionAsync(
            DateTime date,
            decimal pageWidth,
            decimal pageHeight,
            decimal foil,
            decimal tape,
            decimal wischwasser,
            decimal inkBlack,
            decimal inkColor,
            decimal plateDeveloper);

        Task<MaterialConsumptionServiceModel> GetConsumptionByIdAsync(int id);

        Task<bool> EditConsumptionAsync(
            int id,
            DateTime date,
            decimal pageWidth,
            decimal pageHeight,
            decimal foil,
            decimal tape,
            decimal wischwasser,
            decimal inkBlack,
            decimal inkColor,
            decimal plateDeveloper);

        Task<bool> DeleteConsumptionAsync(int id);

        // Paper Waste
        Task<IEnumerable<PaperWasteServiceModel>> AllPaperWastesAsync();

        Task AddPaperWasteAsync(
            DateTime date,
            decimal coreWaste,
            decimal printingWaste,
            int key1,
            decimal value1,
            int key2,
            decimal value2,
            int key3,
            decimal value3,
            int key4,
            decimal value4,
            int key5,
            decimal value5);

        Task<PaperWasteServiceModel> GetPaperWasteByIdAsync(int id);

        Task<bool> EditPaperWasteAsync(
            int id,
            DateTime date,
            decimal coreWaste,
            decimal printingWaste,
            int key1,
            decimal value1,
            int key2,
            decimal value2,
            int key3,
            decimal value3,
            int key4,
            decimal value4,
            int key5,
            decimal value5);

        Task<bool> DeletePaperWasteAsync(int id);
    }
}
