namespace NewspaperSystem.Services.Materials
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models.Materials;
    using Models;

    public interface IMaterialService
    {
        IEnumerable<PaperTypeListServiceModel> AllPaperTypes();

        Task AddPaperTypeAsync(PaperType paperType);

        PaperTypeListServiceModel GetPaperTypeById(int id);

        Task EditPaperTypeAsync(int id, PaperTypeListServiceModel model);

        bool PaperTypeIsUsed(int id);

        Task DeletePaperTypeAsync(int id);
    }
}
