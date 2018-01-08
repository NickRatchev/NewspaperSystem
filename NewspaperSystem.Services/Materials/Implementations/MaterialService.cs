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
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MaterialService : IMaterialService

    {
        private readonly NewspaperSystemDbContext db;

        public MaterialService(NewspaperSystemDbContext db)
        {
            this.db = db;
        }

        #region PaperType

        public async Task<IEnumerable<PaperTypeServiceModel>> AllPaperTypesAsync()
        {
            var result = await this.db
                .PaperTypes
                .OrderByDescending(pt => pt.IsActive)
                .ThenBy(pt => pt.Name)
                .ProjectTo<PaperTypeServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddPaperTypeAsync(
            string name,
            decimal grammage,
            bool isActive)
        {
            await this.db.PaperTypes.AddAsync(new PaperType()
            {
                Name = name,
                Grammage = grammage,
                IsActive = isActive
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<PaperTypeServiceModel> GetPaperTypeByIdAsync(int id)
        {
            var result = await this.db.PaperTypes
                .ProjectTo<PaperTypeServiceModel>()
                .FirstOrDefaultAsync(pt => pt.Id == id);

            return result;
        }

        public async Task<bool> EditPaperTypeAsync(
            int id,
            string name,
            decimal grammage,
            bool isActive)
        {
            var paperType = await this.db.PaperTypes
                .FirstOrDefaultAsync(pt => pt.Id == id);

            if (paperType == null)
            {
                return false;
            }

            paperType.Name = name;
            paperType.Grammage = grammage;
            paperType.IsActive = isActive;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PaperTypeIsUsedAsync(int id)
        {
            var result = await this.db.PaperTypes
                .AnyAsync(pt => pt.Id == id && pt.Orders.Any());

            return result;
        }

        public async Task<bool> DeletePaperTypeAsync(int id)
        {
            var paperType = this.db.PaperTypes
                .FirstOrDefault(pt => pt.Id == id);

            if (paperType == null)
            {
                return false;
            }

            this.db.PaperTypes.Remove(paperType);

            await this.db.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Paper
        public async Task<IEnumerable<PaperServiceModel>> AllPapersAsync()
        {
            var result = await this.db.Papers
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
                .OrderBy(p => p.PaperTypeName)
                .ThenBy(p => p.Date)
                .ToListAsync();

            return result;
        }

        public async Task AddPaperAsync(
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.Papers.AddAsync(new Paper()
            {
                Date = date,
                PaperTypeId = paperTypeId,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<PaperServiceModel> GetPaperByIdAsync(int id)
        {
            var resultold = await this.db.Papers
                .ProjectTo<PaperServiceModel>()
                .FirstOrDefaultAsync(pt => pt.Id == id);

            var result = await this.db.Papers
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
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> EditPaperAsync(
            int id,
            DateTime date,
            int paperTypeId,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.Papers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.PaperTypeId = paperTypeId;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePaperAsync(int id)
        {
            var material = this.db.Papers
                .FirstOrDefault(m => m.Id == id);

            if (material == null)
            {
                return false;
            }
            this.db.Papers.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region ColorInk
        public async Task<IEnumerable<BaseMaterialServiceModel>> AllColorInksAsync()
        {
            var result = await this.db
                .ColorInks
                .OrderBy(m => m.Date)
                .ProjectTo<BaseMaterialServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddColorInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.ColorInks.AddAsync(new ColorInk()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<BaseMaterialServiceModel> GetColorInkByIdAsync(int id)
        {
            var result = await this.db.ColorInks
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task<bool> EditColorInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.ColorInks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteColorInkAsync(int id)
        {
            var material = await this.db.ColorInks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.ColorInks.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }


        #endregion

        #region BlackInk
        public async Task<IEnumerable<BaseMaterialServiceModel>> AllBlackInksAsync()
        {
            var result = await this.db
                .BlackInks
                .OrderBy(m => m.Date)
                .ProjectTo<BaseMaterialServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddBlackInkAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.BlackInks.AddAsync(new BlackInk()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<BaseMaterialServiceModel> GetBlackInkByIdAsync(int id)
        {
            var result = await this.db.BlackInks
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task<bool> EditBlackInkAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.BlackInks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBlackInkAsync(int id)
        {
            var material = await this.db.BlackInks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.BlackInks.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Plate
        public async Task<IEnumerable<BaseMaterialServiceModel>> AllPlatesAsync()
        {
            var result = await this.db
                .Plates
                .OrderBy(m => m.Date)
                .ProjectTo<BaseMaterialServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.Plates.AddAsync(new Plate()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<BaseMaterialServiceModel> GetPlateByIdAsync(int id)
        {
            var result = await this.db.Plates
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task<bool> EditPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.Plates
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePlateAsync(int id)
        {
            var material = await this.db.Plates
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.Plates.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region BlindPlate
        public async Task<IEnumerable<BaseMaterialServiceModel>> AllBlindPlatesAsync()
        {
            var result = await this.db
                .BlindPlates
                .OrderBy(m => m.Date)
                .ProjectTo<BaseMaterialServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddBlindPlateAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.BlindPlates.AddAsync(new BlindPlate()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<BaseMaterialServiceModel> GetBlindPlateByIdAsync(int id)
        {
            var result = await this.db.BlindPlates
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task<bool> EditBlindPlateAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.BlindPlates
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBlindPlateAsync(int id)
        {
            var material = await this.db.BlindPlates
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.BlindPlates.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region PlateDeveloper
        public async Task<IEnumerable<BaseMaterialServiceModel>> AllPlateDevelopersAsync()
        {
            var result = await this.db
                .PlateDevelopers
                .OrderBy(m => m.Date)
                .ProjectTo<BaseMaterialServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddPlateDeveloperAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.PlateDevelopers.AddAsync(new PlateDeveloper()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<BaseMaterialServiceModel> GetPlateDeveloperByIdAsync(int id)
        {
            var result = await this.db.PlateDevelopers
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task<bool> EditPlateDeveloperAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.PlateDevelopers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePlateDeveloperAsync(int id)
        {
            var material = await this.db.PlateDevelopers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.PlateDevelopers.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Wischwasser
        public async Task<IEnumerable<BaseMaterialServiceModel>> AllWischwassersAsync()
        {
            var result = await this.db
                .Wischwassers
                .OrderBy(m => m.Date)
                .ProjectTo<BaseMaterialServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddWischwasserAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.Wischwassers.AddAsync(new Wischwasser()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<BaseMaterialServiceModel> GetWischwasserByIdAsync(int id)
        {
            var result = await this.db.Wischwassers
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task<bool> EditWischwasserAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.Wischwassers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteWischwasserAsync(int id)
        {
            var material = await this.db.Wischwassers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.Wischwassers.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Foil
        public async Task<IEnumerable<BaseMaterialServiceModel>> AllFoilsAsync()
        {
            var result = await this.db
                .Foils
                .OrderBy(m => m.Date)
                .ProjectTo<BaseMaterialServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddFoilAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.Foils.AddAsync(new Foil()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<BaseMaterialServiceModel> GetFoilByIdAsync(int id)
        {
            var result = await this.db.Foils
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task<bool> EditFoilAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.Foils
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFoilAsync(int id)
        {
            var material = await this.db.Foils
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.Foils.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Tape
        public async Task<IEnumerable<BaseMaterialServiceModel>> AllTapesAsync()
        {
            var result = await this.db
                .Tapes
                .OrderBy(m => m.Date)
                .ProjectTo<BaseMaterialServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task AddTapeAsync(
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            await this.db.Tapes.AddAsync(new Tape()
            {
                Date = date,
                Price = price,
                SafetyMargin = safetyMargin
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<BaseMaterialServiceModel> GetTapeByIdAsync(int id)
        {
            var result = await this.db.Tapes
                .ProjectTo<BaseMaterialServiceModel>()
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task<bool> EditTapeAsync(
            int id,
            DateTime date,
            decimal price,
            decimal safetyMargin)
        {
            var material = await this.db.Tapes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.Price = price;
            material.SafetyMargin = safetyMargin;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTapeAsync(int id)
        {
            var material = await this.db.Tapes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.Tapes.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Service Prices
        public async Task<IEnumerable<ServicePriceServiceModel>> AllServicesAsync()
        {
            var result = await this.db
                .ServicePrices
                .ProjectTo<ServicePriceServiceModel>()
                .OrderBy(m => m.Date)
                .ToListAsync();

            return result;
        }

        public async Task AddServiceAsync(
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing)
        {
            await this.db.ServicePrices.AddAsync(new ServicePrice()
            {
                Date = date,
                PlateExposing = plateExposing,
                MachineSetup = machineSetup,
                Impression = impression,
                Packing = packing
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<ServicePriceServiceModel> GetServiceByIdAsync(int id)
        {
            var result = await this.db.ServicePrices
                .ProjectTo<ServicePriceServiceModel>()
                .FirstOrDefaultAsync(pt => pt.Id == id);

            return result;
        }

        public async Task<bool> EditServiceAsync(
            int id,
            DateTime date,
            decimal plateExposing,
            decimal machineSetup,
            decimal impression,
            decimal packing)
        {
            var material = await this.db.ServicePrices
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            material.Date = date;
            material.PlateExposing = plateExposing;
            material.MachineSetup = machineSetup;
            material.Impression = impression;
            material.Packing = packing;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            var material = this.db.ServicePrices
                .FirstOrDefault(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.ServicePrices.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Material Consumption

        public async Task<IEnumerable<MaterialConsumptionServiceModel>> AllConsumptionsAsync()
        {
            var result = await this.db
                .MaterialConsumptions
                .ProjectTo<MaterialConsumptionServiceModel>()
                .OrderBy(m => m.Date)
                .ToListAsync();

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
            await this.db.MaterialConsumptions.AddAsync(new MaterialConsumption()
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

        public async Task<MaterialConsumptionServiceModel> GetConsumptionByIdAsync(int id)
        {
            var result = await this.db.MaterialConsumptions
                .ProjectTo<MaterialConsumptionServiceModel>()
                .FirstOrDefaultAsync(pt => pt.Id == id);

            return result;
        }

        public async Task<bool> EditConsumptionAsync(
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
            var material = await this.db.MaterialConsumptions
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

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

            return true;
        }

        public async Task<bool> DeleteConsumptionAsync(int id)
        {
            var material = await this.db.MaterialConsumptions
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return false;
            }

            this.db.MaterialConsumptions.Remove(material);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Paper Waste

        public async Task<IEnumerable<PaperWasteServiceModel>> AllPaperWastesAsync()
        {
            var result = await this.db
                .PaperWastes
                .ProjectTo<PaperWasteServiceModel>()
                .OrderBy(m => m.Date)
                .ToListAsync();

            return result;
        }

        public async Task AddPaperWasteAsync(
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
            decimal value5)
        {
            await this.db.PaperWastes.AddAsync(new PaperWaste()
            {
                Date = date,
                CoreWaste = coreWaste,
                PrintingWaste = printingWaste,
                Key1 = key1,
                Value1 = value1,
                Key2 = key2,
                Value2 = value2,
                Key3 = key3,
                Value3 = value3,
                Key4 = key4,
                Value4 = value4,
                Key5 = key5,
                Value5 = value5
            });

            await this.db.SaveChangesAsync();
        }

        public async Task<PaperWasteServiceModel> GetPaperWasteByIdAsync(int id)
        {
            var result = await this.db.PaperWastes
                .ProjectTo<PaperWasteServiceModel>()
                .FirstOrDefaultAsync(pt => pt.Id == id);

            return result;
        }

        public async Task<bool> EditPaperWasteAsync(
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
            decimal value5)
        {
            var paperWaste = await this.db.PaperWastes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (paperWaste == null)
            {
                return false;
            }

            paperWaste.Date = date;
            paperWaste.CoreWaste = coreWaste;
            paperWaste.PrintingWaste = printingWaste;
            paperWaste.Key1 = key1;
            paperWaste.Value1 = value1;
            paperWaste.Key2 = key2;
            paperWaste.Value2 = value2;
            paperWaste.Key3 = key3;
            paperWaste.Value3 = value3;
            paperWaste.Key4 = key4;
            paperWaste.Value4 = value4;
            paperWaste.Key5 = key5;
            paperWaste.Value5 = value5;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePaperWasteAsync(int id)
        {
            var paperWaste = await this.db.PaperWastes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (paperWaste == null)
            {
                return false;
            }

            this.db.PaperWastes.Remove(paperWaste);

            await this.db.SaveChangesAsync();

            return true;
        }

        #endregion
    }
}
