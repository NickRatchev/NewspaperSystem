namespace NewspaperSystem.Services.Materials.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Data.Models.Materials;
    using Models;

    public class MaterialService : IMaterialService

    {
        private readonly NewspaperSystemDbContext db;

        public MaterialService(NewspaperSystemDbContext db)
        {
            this.db = db;
        }

        #region PaperType

        public IEnumerable<PaperTypeServiceModel> AllPaperTypes()
        {
            var result = this.db
                .PaperTypes
                .ProjectTo<PaperTypeServiceModel>()
                .ToList()
                .OrderByDescending(pt => pt.IsActive)
                .ThenBy(pt => pt.Name);

            return result;
        }

        public async Task AddPaperTypeAsync(
            string name,
            decimal grammage,
            bool isActive)
        {
            this.db.PaperTypes.Add(new PaperType()
            {
                Name = name,
                Grammage = grammage,
                IsActive = isActive
            });

            await this.db.SaveChangesAsync();
        }

        public PaperTypeServiceModel GetPaperTypeById(int id)
        {
            var result = this.db.PaperTypes
                .ProjectTo<PaperTypeServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditPaperTypeAsync(
            int id,
            string name,
            decimal grammage,
            bool isActive)
        {
            var paperType = this.db.PaperTypes
                .FirstOrDefault(pt => pt.Id == id);

            paperType.Name = name;
            paperType.Grammage = grammage;
            paperType.IsActive = isActive;

            await this.db.SaveChangesAsync();
        }

        public bool PaperTypeIsUsed(int id)
        {
            var result = this.db.PaperTypes.Any(pt => pt.Orders.Any());

            return result;
        }

        public async Task DeletePaperTypeAsync(int id)
        {
            var paperType = this.db.PaperTypes.FirstOrDefault(pt => pt.Id == id);
            this.db.PaperTypes.Remove(paperType);
            await this.db.SaveChangesAsync();
        }
        #endregion

        #region Paper
        public IEnumerable<PaperServiceModel> AllPapers()
        {
            var result = this.db.Papers
                .Where(p => p.PaperType.IsActive)
                .Select(p => new PaperServiceModel()
                {
                    Id = p.Id,
                    Date = p.Date,
                    PaperTypeId = p.PaperTypeId,
                    PaperTypeName = $"{p.PaperType.Name} {p.PaperType.Grammage:F1}",
                    Price = p.Price,
                    SafetyMargin = p.SafetyMargin
                })
                .ToList()
                .OrderBy(p => p.PaperTypeName)
                .ThenBy(p => p.Date);

            return result;
        }

        public async Task AddPaperAsync(
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin)
        {
            this.db.Papers.Add(new Paper()
            {
                Date = date,
                PaperTypeId = paperTypeId,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public PaperServiceModel GetPaperById(int id)
        {
            var resultold = this.db.Papers
                .ProjectTo<PaperServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            var result = this.db.Papers
                .Where(p => p.Id == id)
                .Select(p => new PaperServiceModel()
                {
                    Id = p.Id,
                    Date = p.Date,
                    PaperTypeId = p.PaperTypeId,
                    PaperTypeName = $"{p.PaperType.Name} {p.PaperType.Grammage} гр.",
                    Price = p.Price,
                    SafetyMargin = p.SafetyMargin
                })
                .FirstOrDefault();

            return result;
        }

        public async Task EditPaperAsync(
            int id,
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.Papers
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.PaperTypeId = paperTypeId;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeletePaperAsync(int id)
        {
            var material = this.db.Papers.FirstOrDefault(m => m.Id == id);
            this.db.Papers.Remove(material);
            await this.db.SaveChangesAsync();
        }

        #endregion

        #region ColorInk
        public IEnumerable<BaseMaterialServiceModel> AllColorInks()
        {
            var result = this.db
                .ColorInks
                .ProjectTo<BaseMaterialServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddColorInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            this.db.ColorInks.Add(new ColorInk()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public BaseMaterialServiceModel GetColorInkById(int id)
        {
            var result = this.db.ColorInks
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditColorInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.ColorInks
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteColorInkAsync(int id)
        {
            var material = this.db.ColorInks.FirstOrDefault(m => m.Id == id);
            this.db.ColorInks.Remove(material);
            await this.db.SaveChangesAsync();
        }


        #endregion

        #region BlackInk
        public IEnumerable<BaseMaterialServiceModel> AllBlackInks()
        {
            var result = this.db
                .BlackInks
                .ProjectTo<BaseMaterialServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddBlackInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            this.db.BlackInks.Add(new BlackInk()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public BaseMaterialServiceModel GetBlackInkById(int id)
        {
            var result = this.db.BlackInks
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditBlackInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.BlackInks
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteBlackInkAsync(int id)
        {
            var material = this.db.BlackInks.FirstOrDefault(m => m.Id == id);
            this.db.BlackInks.Remove(material);
            await this.db.SaveChangesAsync();
        }


        #endregion

        #region Plate
        public IEnumerable<BaseMaterialServiceModel> AllPlates()
        {
            var result = this.db
                .Plates
                .ProjectTo<BaseMaterialServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            this.db.Plates.Add(new Plate()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public BaseMaterialServiceModel GetPlateById(int id)
        {
            var result = this.db.Plates
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.Plates
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeletePlateAsync(int id)
        {
            var material = this.db.Plates.FirstOrDefault(m => m.Id == id);
            this.db.Plates.Remove(material);
            await this.db.SaveChangesAsync();
        }


        #endregion

        #region BlindPlate
        public IEnumerable<BaseMaterialServiceModel> AllBlindPlates()
        {
            var result = this.db
                .BlindPlates
                .ProjectTo<BaseMaterialServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddBlindPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            this.db.BlindPlates.Add(new BlindPlate()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public BaseMaterialServiceModel GetBlindPlateById(int id)
        {
            var result = this.db.BlindPlates
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditBlindPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.BlindPlates
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteBlindPlateAsync(int id)
        {
            var material = this.db.BlindPlates.FirstOrDefault(m => m.Id == id);
            this.db.BlindPlates.Remove(material);
            await this.db.SaveChangesAsync();
        }


        #endregion

        #region PlateDeveloper
        public IEnumerable<BaseMaterialServiceModel> AllPlateDevelopers()
        {
            var result = this.db
                .PlateDevelopers
                .ProjectTo<BaseMaterialServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddPlateDeveloperAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            this.db.PlateDevelopers.Add(new PlateDeveloper()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public BaseMaterialServiceModel GetPlateDeveloperById(int id)
        {
            var result = this.db.PlateDevelopers
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditPlateDeveloperAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.PlateDevelopers
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeletePlateDeveloperAsync(int id)
        {
            var material = this.db.PlateDevelopers.FirstOrDefault(m => m.Id == id);
            this.db.PlateDevelopers.Remove(material);
            await this.db.SaveChangesAsync();
        }


        #endregion

        #region Wischwasser
        public IEnumerable<BaseMaterialServiceModel> AllWischwassers()
        {
            var result = this.db
                .Wischwassers
                .ProjectTo<BaseMaterialServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddWischwasserAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            this.db.Wischwassers.Add(new Wischwasser()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public BaseMaterialServiceModel GetWischwasserById(int id)
        {
            var result = this.db.Wischwassers
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditWischwasserAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.Wischwassers
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteWischwasserAsync(int id)
        {
            var material = this.db.Wischwassers.FirstOrDefault(m => m.Id == id);
            this.db.Wischwassers.Remove(material);
            await this.db.SaveChangesAsync();
        }


        #endregion

        #region Foil
        public IEnumerable<BaseMaterialServiceModel> AllFoils()
        {
            var result = this.db
                .Foils
                .ProjectTo<BaseMaterialServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddFoilAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            this.db.Foils.Add(new Foil()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public BaseMaterialServiceModel GetFoilById(int id)
        {
            var result = this.db.Foils
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditFoilAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.Foils
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteFoilAsync(int id)
        {
            var material = this.db.Foils.FirstOrDefault(m => m.Id == id);
            this.db.Foils.Remove(material);
            await this.db.SaveChangesAsync();
        }


        #endregion

        #region Tape
        public IEnumerable<BaseMaterialServiceModel> AllTapes()
        {
            var result = this.db
                .Tapes
                .ProjectTo<BaseMaterialServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddTapeAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            this.db.Tapes.Add(new Tape()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public BaseMaterialServiceModel GetTapeById(int id)
        {
            var result = this.db.Tapes
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditTapeAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = this.db.Tapes
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteTapeAsync(int id)
        {
            var material = this.db.Tapes.FirstOrDefault(m => m.Id == id);
            this.db.Tapes.Remove(material);
            await this.db.SaveChangesAsync();
        }


        #endregion

        #region Service Prices
        public IEnumerable<ServicePriceServiceModel> AllServices()
        {
            var result = this.db
                .ServicePrices
                .ProjectTo<ServicePriceServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddServiceAsync(
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing)
        {
            this.db.ServicePrices.Add(new ServicePrice()
            {
                Date = date,
                PlateExposing = plateExposing,
                MachineSetup = machineSetup,
                Impression = impression,
                Packing = packing
            });

            await this.db.SaveChangesAsync();
        }

        public ServicePriceServiceModel GetServiceById(int id)
        {
            var result = this.db.ServicePrices
                .ProjectTo<ServicePriceServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditServiceAsync(
            int id,
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing)
        {
            var material = this.db.ServicePrices
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.PlateExposing = plateExposing;
            material.MachineSetup = machineSetup;
            material.Impression = impression;
            material.Packing = packing;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var material = this.db.ServicePrices.FirstOrDefault(m => m.Id == id);
            this.db.ServicePrices.Remove(material);
            await this.db.SaveChangesAsync();
        }

        #endregion

        #region Material Consumption

        public IEnumerable<MaterialConsumptionServiceModel> AllConsumptions()
        {
            var result = this.db
                .MaterialConsumptions
                .ProjectTo<MaterialConsumptionServiceModel>()
                .ToList()
                .OrderBy(m => m.Date);

            return result;
        }

        public async Task AddConsumptionAsync(
            DateTime date,
            decimal pageWidth,
            decimal pageHeight,
            decimal foil,
            decimal tape,
            decimal wischwasser,
            decimal inkBlack,
            decimal inkColor,
            decimal plateDeveloper)
        {
            this.db.MaterialConsumptions.Add(new MaterialConsumption()
            {
                Date = date,
                PageWidth = pageWidth,
                PageHeight = pageHeight,
                Foil = foil,
                Tape = tape,
                Wischwasser = wischwasser,
                InkBlack = inkBlack,
                InkColor = inkColor,
                PlateDeveloper = plateDeveloper
            });

            await this.db.SaveChangesAsync();
        }

        public MaterialConsumptionServiceModel GetConsumptionById(int id)
        {
            var result = this.db.MaterialConsumptions
                .ProjectTo<MaterialConsumptionServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditConsumptionAsync(
            int id,
            DateTime date,
            decimal pageWidth,
            decimal pageHeight,
            decimal foil,
            decimal tape,
            decimal wischwasser,
            decimal inkBlack,
            decimal inkColor,
            decimal plateDeveloper)
        {
            var material = this.db.MaterialConsumptions
                .FirstOrDefault(m => m.Id == id);

            material.Date = date;
            material.PageWidth = pageWidth;
            material.PageHeight = pageHeight;
            material.Foil = foil;
            material.Tape = tape;
            material.Wischwasser = wischwasser;
            material.InkBlack = inkBlack;
            material.InkColor = inkColor;
            material.PlateDeveloper = plateDeveloper;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteConsumptionAsync(int id)
        {
            var material = this.db.MaterialConsumptions.FirstOrDefault(m => m.Id == id);
            this.db.MaterialConsumptions.Remove(material);
            await this.db.SaveChangesAsync();
        }

        #endregion
    }
}
