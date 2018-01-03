namespace NewspaperSystem.Web.Areas.Materials.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Models.Materials;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using NewspaperSystem.Services.Materials;
    using NewspaperSystem.Services.Materials.Models;

    [Area("Materials")]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class HomeController : Controller
    {
        private readonly IMaterialService materials;

        public HomeController(IMaterialService materials)
        {
            this.materials = materials;
        }

        public IActionResult AllPaperTypes()
        {
            return View(this.materials.AllPaperTypes());
        }

        public IActionResult AddPaperType() => View(new PaperTypeViewModel());

        [HttpPost]
        public async Task<IActionResult> AddPaperType(PaperTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var paperType = new PaperType()
            {
                Name = model.Name,
                Grammage = model.Grammage,
                IsActive = model.IsActive
            };

            await this.materials.AddPaperTypeAsync(paperType);

            return RedirectToAction(nameof(AllPaperTypes));
        }

        public IActionResult EditPaperType(int id)
        {
            var paperType = this.materials.GetPaperTypeById(id);

            if (paperType==null)
            {
                return NotFound();
            }

            var model = Mapper.Map<PaperTypeViewModel>(paperType);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditPaperType(int id, PaperTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var paperType = new PaperTypeListServiceModel()
            {
                Name = model.Name,
                Grammage = model.Grammage,
                IsActive = model.IsActive
            };

            this.materials.EditPaperTypeAsync(id, paperType);

            return RedirectToAction(nameof(AllPaperTypes));
        }

        public async Task<IActionResult> DeletePaperType(int id)
        {
            var paperType = this.materials.GetPaperTypeById(id);

            if (paperType == null)
            {
                return NotFound();
            }

            var paperIsUsed = this.materials.PaperTypeIsUsed(id);

            if (paperIsUsed)
            {
                this.TempData["SuccessMessage"] = $"This paper \"{paperType.Name} - {paperType.Grammage} гр.\" is used and cannot be deleted! You can deactivate!";

                return RedirectToAction(nameof(AllPaperTypes));
            }
            else
            {
                await this.materials.DeletePaperTypeAsync(id);

                this.TempData["SuccessMessage"] = $"The paper \"{paperType.Name} - {paperType.Grammage} гр.\" was deleted!";

                return RedirectToAction(nameof(AllPaperTypes));
            }
        }
    }
}
