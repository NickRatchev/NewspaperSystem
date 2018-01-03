namespace NewspaperSystem.Web.Areas.Materials.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
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

        #region PaperType

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

            await this.materials.AddPaperTypeAsync(
                model.Name,
                model.Grammage,
                model.IsActive);

            return RedirectToAction(nameof(AllPaperTypes));
        }

        public IActionResult EditPaperType(int id)
        {
            var paperType = this.materials.GetPaperTypeById(id);

            if (paperType == null)
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

            this.materials.EditPaperTypeAsync(
                id,
                model.Name,
                model.Grammage,
                model.IsActive);

            return RedirectToAction(nameof(AllPaperTypes));
        }

        public async Task<IActionResult> DeletePaperType(int id)
        {
            var paperType = this.materials.GetPaperTypeById(id);

            if (paperType==null)
            {
                return NotFound();
                return View(AllColorInk());
            }

            return View(new PaperTypeDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyPaperType(int id)
        {
            var paperType = this.materials.GetPaperTypeById(id);

            if (paperType == null)
            {
                return NotFound();
            }

            var paperIsUsed = this.materials.PaperTypeIsUsed(id);

            if (paperIsUsed)
            {
                this.TempData["SuccessMessage"] =
                    $"This paper \"{paperType.Name} - {paperType.Grammage} гр.\" is used and cannot be deleted! You can deactivate!";

                return RedirectToAction(nameof(AllPaperTypes));
            }
            else
            {
                await this.materials.DeletePaperTypeAsync(id);

                this.TempData["SuccessMessage"] =
                    $"The paper \"{paperType.Name} - {paperType.Grammage} гр.\" was deleted!";

                return RedirectToAction(nameof(AllPaperTypes));
            }
        }

        #endregion

        #region ColorInk

        public IActionResult AllColorInk()
        {
            return View(this.materials.AllColorInks());
        }

        public IActionResult AddColorInk() => View(new BaseMaterialViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddColorInk(BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddColorInkAsync(
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllColorInk));
        }

        public IActionResult EditColorInk(int id)
        {
            var material = this.materials.GetColorInkById(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditColorInk(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.materials.EditColorInkAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllColorInk));
        }

        public async Task<IActionResult> DeleteColorInk(int id)
        {
            var material = this.materials.GetColorInkById(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new BaseMaterialDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyColorInk(int id)
        {
            var material = this.materials.GetColorInkById(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeleteColorInkAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllColorInk));
            }
        }

        #endregion

        #region BlackInk

        public IActionResult AllBlackInk()
        {
            return View(this.materials.AllBlackInks());
        }

        public IActionResult AddBlackInk() => View(new BaseMaterialViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddBlackInk(BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddBlackInkAsync(
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllBlackInk));
        }

        public IActionResult EditBlackInk(int id)
        {
            var material = this.materials.GetBlackInkById(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditBlackInk(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.materials.EditBlackInkAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllBlackInk));
        }

        public async Task<IActionResult> DeleteBlackInk(int id)
        {
            var material = this.materials.GetBlackInkById(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new BaseMaterialDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyBlackInk(int id)
        {
            var material = this.materials.GetBlackInkById(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeleteBlackInkAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllBlackInk));
            }
        }

        #endregion

        #region Plate

        public IActionResult AllPlate()
        {
            return View(this.materials.AllPlates());
        }

        public IActionResult AddPlate() => View(new BaseMaterialViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddPlate(BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddPlateAsync(
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllPlate));
        }

        public IActionResult EditPlate(int id)
        {
            var material = this.materials.GetPlateById(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditPlate(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.materials.EditPlateAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllPlate));
        }

        public async Task<IActionResult> DeletePlate(int id)
        {
            var material = this.materials.GetPlateById(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new BaseMaterialDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyPlate(int id)
        {
            var material = this.materials.GetPlateById(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeletePlateAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllPlate));
            }
        }

        #endregion

        #region BlindPlate

        public IActionResult AllBlindPlate()
        {
            return View(this.materials.AllBlindPlates());
        }

        public IActionResult AddBlindPlate() => View(new BaseMaterialViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddBlindPlate(BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddBlindPlateAsync(
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllBlindPlate));
        }

        public IActionResult EditBlindPlate(int id)
        {
            var material = this.materials.GetBlindPlateById(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditBlindPlate(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.materials.EditBlindPlateAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllBlindPlate));
        }

        public async Task<IActionResult> DeleteBlindPlate(int id)
        {
            var material = this.materials.GetBlindPlateById(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new BaseMaterialDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyBlindPlate(int id)
        {
            var material = this.materials.GetBlindPlateById(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeleteBlindPlateAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllBlindPlate));
            }
        }

        #endregion

        #region PlateDeveloper

        public IActionResult AllPlateDeveloper()
        {
            return View(this.materials.AllPlateDevelopers());
        }

        public IActionResult AddPlateDeveloper() => View(new BaseMaterialViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddPlateDeveloper(BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddPlateDeveloperAsync(
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllPlateDeveloper));
        }

        public IActionResult EditPlateDeveloper(int id)
        {
            var material = this.materials.GetPlateDeveloperById(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditPlateDeveloper(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.materials.EditPlateDeveloperAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllPlateDeveloper));
        }

        public async Task<IActionResult> DeletePlateDeveloper(int id)
        {
            var material = this.materials.GetPlateDeveloperById(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new BaseMaterialDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyPlateDeveloper(int id)
        {
            var material = this.materials.GetPlateDeveloperById(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeletePlateDeveloperAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllPlateDeveloper));
            }
        }

        #endregion

        #region Wischwasser

        public IActionResult AllWischwasser()
        {
            return View(this.materials.AllWischwassers());
        }

        public IActionResult AddWischwasser() => View(new BaseMaterialViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddWischwasser(BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddWischwasserAsync(
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllWischwasser));
        }

        public IActionResult EditWischwasser(int id)
        {
            var material = this.materials.GetWischwasserById(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditWischwasser(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.materials.EditWischwasserAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllWischwasser));
        }

        public async Task<IActionResult> DeleteWischwasser(int id)
        {
            var material = this.materials.GetWischwasserById(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new BaseMaterialDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyWischwasser(int id)
        {
            var material = this.materials.GetWischwasserById(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeleteWischwasserAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllWischwasser));
            }
        }

        #endregion

        #region Foil

        public IActionResult AllFoil()
        {
            return View(this.materials.AllFoils());
        }

        public IActionResult AddFoil() => View(new BaseMaterialViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddFoil(BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddFoilAsync(
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllFoil));
        }

        public IActionResult EditFoil(int id)
        {
            var material = this.materials.GetFoilById(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditFoil(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.materials.EditFoilAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllFoil));
        }

        public async Task<IActionResult> DeleteFoil(int id)
        {
            var material = this.materials.GetFoilById(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new BaseMaterialDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyFoil(int id)
        {
            var material = this.materials.GetFoilById(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeleteFoilAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllFoil));
            }
        }

        #endregion

        #region Tape

        public IActionResult AllTape()
        {
            return View(this.materials.AllTapes());
        }

        public IActionResult AddTape() => View(new BaseMaterialViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddTape(BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddTapeAsync(
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllTape));
        }

        public IActionResult EditTape(int id)
        {
            var material = this.materials.GetTapeById(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditTape(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.materials.EditTapeAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllTape));
        }

        public async Task<IActionResult> DeleteTape(int id)
        {
            var material = this.materials.GetTapeById(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new BaseMaterialDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyTape(int id)
        {
            var material = this.materials.GetTapeById(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeleteTapeAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllTape));
            }
        }

        #endregion
    }
}
