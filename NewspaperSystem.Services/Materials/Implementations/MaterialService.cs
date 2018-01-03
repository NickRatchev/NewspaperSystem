namespace NewspaperSystem.Services.Materials.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models.Materials;
    using Models;

    class MaterialService : IMaterialService

    {
        private readonly NewspaperSystemDbContext db;

        public MaterialService(NewspaperSystemDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PaperTypeListServiceModel> AllPaperTypes()
        {
            var result = this.db
                .PaperTypes
                .ProjectTo<PaperTypeListServiceModel>()
                .ToList()
                .OrderBy(pt => pt.Name);

            return result;
        }

        public async Task AddPaperTypeAsync(PaperType paperType)
        {
            this.db.PaperTypes.Add(paperType);

            await this.db.SaveChangesAsync();
        }

        public PaperTypeListServiceModel GetPaperTypeById(int id)
        {
            var result = this.db.PaperTypes
                .ProjectTo<PaperTypeListServiceModel>()
                .FirstOrDefault(pt => pt.Id == id);

            return result;
        }

        public async Task EditPaperTypeAsync(int id, PaperTypeListServiceModel model)
        {
            var paperType = this.db.PaperTypes
                .FirstOrDefault(pt => pt.Id == id);

            paperType.Name = model.Name;
            paperType.Grammage = model.Grammage;
            paperType.IsActive = model.IsActive;

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
    }
}
