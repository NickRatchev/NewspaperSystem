﻿namespace NewspaperSystem.Services.Materials
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
        Task<IEnumerable<PaperTypeServiceModel>> AllPaperTypesAsync();

        Task AddPaperTypeAsync(
            string name,
            decimal grammage,
            bool isActive);

        Task<PaperTypeServiceModel> GetPaperTypeByIdAsync(int id);

        Task EditPaperTypeAsync(
            int id,
            string name,
            decimal grammage,
            bool isActive);

        Task<bool> PaperTypeIsUsedAsync(int id);

        Task DeletePaperTypeAsync(int id);

        // Paper
        Task<IEnumerable<PaperServiceModel>> AllPapersAsync();

        Task AddPaperAsync(
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin);

        Task<PaperServiceModel> GetPaperByIdAsync(int id);

        Task EditPaperAsync(
            int id,
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin);

        Task DeletePaperAsync(int id);


        // Color Ink
        Task<IEnumerable<BaseMaterialServiceModel>> AllColorInksAsync();

        Task AddColorInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetColorInkByIdAsync(int id);

        Task EditColorInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteColorInkAsync(int id);

        // Black Ink
        Task<IEnumerable<BaseMaterialServiceModel>> AllBlackInksAsync();

        Task AddBlackInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetBlackInkByIdAsync(int id);

        Task EditBlackInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteBlackInkAsync(int id);

        // Plate
        Task<IEnumerable<BaseMaterialServiceModel>> AllPlatesAsync();

        Task AddPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetPlateByIdAsync(int id);

        Task EditPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeletePlateAsync(int id);

        // BlindPlate
        Task<IEnumerable<BaseMaterialServiceModel>> AllBlindPlatesAsync();

        Task AddBlindPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetBlindPlateByIdAsync(int id);

        Task EditBlindPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteBlindPlateAsync(int id);

        // PlateDeveloper
        Task<IEnumerable<BaseMaterialServiceModel>> AllPlateDevelopersAsync();

        Task AddPlateDeveloperAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetPlateDeveloperByIdAsync(int id);

        Task EditPlateDeveloperAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeletePlateDeveloperAsync(int id);

        // Wischwasser
        Task<IEnumerable<BaseMaterialServiceModel>> AllWischwassersAsync();

        Task AddWischwasserAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetWischwasserByIdAsync(int id);

        Task EditWischwasserAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteWischwasserAsync(int id);

        // Foil
        Task<IEnumerable<BaseMaterialServiceModel>> AllFoilsAsync();

        Task AddFoilAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetFoilByIdAsync(int id);

        Task EditFoilAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteFoilAsync(int id);

        // Tape
        Task<IEnumerable<BaseMaterialServiceModel>> AllTapesAsync();

        Task AddTapeAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task<BaseMaterialServiceModel> GetTapeByIdAsync(int id);

        Task EditTapeAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin);

        Task DeleteTapeAsync(int id);

        // Service Prices
        Task<IEnumerable<ServicePriceServiceModel>> AllServicesAsync();

        Task AddServiceAsync(
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing);

        Task<ServicePriceServiceModel> GetServiceByIdAsync(int id);

        Task EditServiceAsync(
            int id,
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing);

        Task DeleteServiceAsync(int id);

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

        Task EditPaperWasteAsync(
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

        Task DeletePaperWasteAsync(int id);
    }
}
