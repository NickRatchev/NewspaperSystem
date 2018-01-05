namespace NewspaperSystem.Services.Materials
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Data.Models.Materials;
    using Models;

    public interface IMaterialService
    {
        // Paper Type
        IEnumerable<PaperTypeServiceModel> AllPaperTypes();

        Task AddPaperTypeAsync(
            string name,
            decimal grammage,
            bool isActive);

        PaperTypeServiceModel GetPaperTypeById(int id);

        Task EditPaperTypeAsync(
            int id,
            string name,
            decimal grammage,
            bool isActive);

        bool PaperTypeIsUsed(int id);

        Task DeletePaperTypeAsync(int id);

        // Paper
        IEnumerable<PaperServiceModel> AllPapers();

        Task AddPaperAsync(
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin);

        PaperServiceModel GetPaperById(int id);

        Task EditPaperAsync(
            int id,
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin);

        Task DeletePaperAsync(int id);


        // Color Ink
        IEnumerable<BaseMaterialServiceModel> AllColorInks();

        Task AddColorInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        BaseMaterialServiceModel GetColorInkById(int id);

        Task EditColorInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteColorInkAsync(int id);

        // Black Ink
        IEnumerable<BaseMaterialServiceModel> AllBlackInks();

        Task AddBlackInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        BaseMaterialServiceModel GetBlackInkById(int id);

        Task EditBlackInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteBlackInkAsync(int id);

        // Plate
        IEnumerable<BaseMaterialServiceModel> AllPlates();

        Task AddPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        BaseMaterialServiceModel GetPlateById(int id);

        Task EditPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeletePlateAsync(int id);

        // BlindPlate
        IEnumerable<BaseMaterialServiceModel> AllBlindPlates();

        Task AddBlindPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        BaseMaterialServiceModel GetBlindPlateById(int id);

        Task EditBlindPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteBlindPlateAsync(int id);

        // PlateDeveloper
        IEnumerable<BaseMaterialServiceModel> AllPlateDevelopers();

        Task AddPlateDeveloperAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        BaseMaterialServiceModel GetPlateDeveloperById(int id);

        Task EditPlateDeveloperAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeletePlateDeveloperAsync(int id);

        // Wischwasser
        IEnumerable<BaseMaterialServiceModel> AllWischwassers();

        Task AddWischwasserAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        BaseMaterialServiceModel GetWischwasserById(int id);

        Task EditWischwasserAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteWischwasserAsync(int id);

        // Foil
        IEnumerable<BaseMaterialServiceModel> AllFoils();

        Task AddFoilAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        BaseMaterialServiceModel GetFoilById(int id);

        Task EditFoilAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteFoilAsync(int id);

        // Tape
        IEnumerable<BaseMaterialServiceModel> AllTapes();

        Task AddTapeAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        BaseMaterialServiceModel GetTapeById(int id);

        Task EditTapeAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteTapeAsync(int id);

        // Service Prices
        IEnumerable<ServicePriceServiceModel> AllServices();

        Task AddServiceAsync(
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing);

        ServicePriceServiceModel GetServiceById(int id);

        Task EditServiceAsync(
            int id,
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing);

        Task DeleteServiceAsync(int id);

        // Material Consumptions
        IEnumerable<MaterialConsumptionServiceModel> AllConsumptions();

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

        MaterialConsumptionServiceModel GetConsumptionById(int id);

        Task EditConsumptionAsync(
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

        Task DeleteConsumptionAsync(int id);
    }
}
