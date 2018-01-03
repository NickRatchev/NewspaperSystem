namespace NewspaperSystem.Services.Materials.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
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
        public IEnumerable<PaperTypeListServiceModel> AllPaperTypes()
        {
            var result = this.db
                .PaperTypes
                .ProjectTo<PaperTypeListServiceModel>()
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

        public PaperTypeListServiceModel GetPaperTypeById(int id)
        {
            var result = this.db.PaperTypes
                .ProjectTo<PaperTypeListServiceModel>()
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

        #region ColorInk
        public IEnumerable<BaseMaterialServiceModel> AllColorInks()
        {
            var result = this.db
                .ColorInks
                .ProjectTo <BaseMaterialServiceModel> ()
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
    }
}
