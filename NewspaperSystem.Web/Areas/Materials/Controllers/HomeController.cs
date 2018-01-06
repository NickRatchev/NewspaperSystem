namespace NewspaperSystem.Web.Areas.Materials.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> AllPaperTypes()
        {
            return View(await this.materials.AllPaperTypesAsync());
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

        public async Task<IActionResult> EditPaperType(int id)
        {
            var paperType = await this.materials.GetPaperTypeByIdAsync(id);

            if (paperType == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<PaperTypeViewModel>(paperType);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPaperType(int id, PaperTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var paperType = new PaperTypeServiceModel()
            {
                Name = model.Name,
                Grammage = model.Grammage,
                IsActive = model.IsActive
            };

            await this.materials.EditPaperTypeAsync(
                id,
                model.Name,
                model.Grammage,
                model.IsActive);

            return RedirectToAction(nameof(AllPaperTypes));
        }

        public async Task<IActionResult> DeletePaperType(int id)
        {
            var paperType = await this.materials.GetPaperTypeByIdAsync(id);

            if (paperType == null)
            {
                return NotFound();
            }

            return View(new PaperTypeDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyPaperType(int id)
        {
            var paperType = await this.materials.GetPaperTypeByIdAsync(id);

            if (paperType == null)
            {
                return NotFound();
            }

            var paperIsUsed = await this.materials.PaperTypeIsUsedAsync(id);

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

        #region Paper

        public async Task<IActionResult> AllPaper()
        {
            return View(await this.materials.AllPapersAsync());
        }

        public async Task<IActionResult> AddPaper()
        {
            var paperTypes = await GetAllPaperTypesAsync();

            return View(new PaperViewModel()
            {
                Date = DateTime.UtcNow,
                PaperTypes = paperTypes
            });
        }


        [HttpPost]
        public async Task<IActionResult> AddPaper(PaperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var paperTypes = await GetAllPaperTypesAsync();

                model.PaperTypes = paperTypes;

                return View(model);
            }

            await this.materials.AddPaperAsync(
                model.Date,
                model.PaperTypeId,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllPaper));
        }

        public async Task<IActionResult> EditPaper(int id)
        {
            var material = await this.materials.GetPaperByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var paperTypes = await GetAllPaperTypesAsync();
            var model = Mapper.Map<PaperViewModel>(material);

            model.PaperTypes = paperTypes;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPaper(int id, PaperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var paperTypes = await GetAllPaperTypesAsync();

                model.PaperTypes = paperTypes;

                return View(model);
            }
            await this.materials.EditPaperAsync(

                id,
                model.Date,
                model.PaperTypeId,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllPaper));
        }

        public async Task<IActionResult> DeletePaper(int id)
        {
            var material = await this.materials.GetPaperByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new PaperDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyPaper(int id)
        {
            var material = await this.materials.GetPaperByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeletePaperAsync(id);

                this.TempData["SuccessMessage"] = $"Selected paper was successfuly deleted!";

                return RedirectToAction(nameof(AllPaper));
            }
        }

        #endregion

        #region ColorInk

        public async Task<IActionResult> AllColorInk()
        {
            return View(await this.materials.AllColorInksAsync());
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

        public async Task<IActionResult> EditColorInk(int id)
        {
            var material = await this.materials.GetColorInkByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditColorInk(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditColorInkAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllColorInk));
        }

        public async Task<IActionResult> DeleteColorInk(int id)
        {
            var material = await this.materials.GetColorInkByIdAsync(id);

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
            var material = await this.materials.GetColorInkByIdAsync(id);

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

        public async Task<IActionResult> AllBlackInk()
        {
            return View(await this.materials.AllBlackInksAsync());
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

        public async Task<IActionResult> EditBlackInk(int id)
        {
            var material = await this.materials.GetBlackInkByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlackInk(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditBlackInkAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllBlackInk));
        }

        public async Task<IActionResult> DeleteBlackInk(int id)
        {
            var material = await this.materials.GetBlackInkByIdAsync(id);

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
            var material = await this.materials.GetBlackInkByIdAsync(id);

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

        public async Task<IActionResult> AllPlate()
        {
            return View(await this.materials.AllPlatesAsync());
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

        public async Task<IActionResult> EditPlate(int id)
        {
            var material = await this.materials.GetPlateByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlate(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditPlateAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllPlate));
        }

        public async Task<IActionResult> DeletePlate(int id)
        {
            var material = await this.materials.GetPlateByIdAsync(id);

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
            var material = await this.materials.GetPlateByIdAsync(id);

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

        public async Task<IActionResult> AllBlindPlate()
        {
            return View(await this.materials.AllBlindPlatesAsync());
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

        public async Task<IActionResult> EditBlindPlate(int id)
        {
            var material = await this.materials.GetBlindPlateByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlindPlate(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditBlindPlateAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllBlindPlate));
        }

        public async Task<IActionResult> DeleteBlindPlate(int id)
        {
            var material = await this.materials.GetBlindPlateByIdAsync(id);

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
            var material = await this.materials.GetBlindPlateByIdAsync(id);

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

        public async Task<IActionResult> AllPlateDeveloper()
        {
            return View(await this.materials.AllPlateDevelopersAsync());
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

        public async Task<IActionResult> EditPlateDeveloper(int id)
        {
            var material = await this.materials.GetPlateDeveloperByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlateDeveloper(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditPlateDeveloperAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllPlateDeveloper));
        }

        public async Task<IActionResult> DeletePlateDeveloper(int id)
        {
            var material = await this.materials.GetPlateDeveloperByIdAsync(id);

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
            var material = await this.materials.GetPlateDeveloperByIdAsync(id);

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

        public async Task<IActionResult> AllWischwasser()
        {
            return View(await this.materials.AllWischwassersAsync());
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

        public async Task<IActionResult> EditWischwasser(int id)
        {
            var material = await this.materials.GetWischwasserByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditWischwasser(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditWischwasserAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllWischwasser));
        }

        public async Task<IActionResult> DeleteWischwasser(int id)
        {
            var material = await this.materials.GetWischwasserByIdAsync(id);

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
            var material = await this.materials.GetWischwasserByIdAsync(id);

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

        public async Task<IActionResult> AllFoil()
        {
            return View(await this.materials.AllFoilsAsync());
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

        public async Task<IActionResult> EditFoil(int id)
        {
            var material = await this.materials.GetFoilByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditFoil(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditFoilAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllFoil));
        }

        public async Task<IActionResult> DeleteFoil(int id)
        {
            var material = await this.materials.GetFoilByIdAsync(id);

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
            var material = await this.materials.GetFoilByIdAsync(id);

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

        public async Task<IActionResult> AllTape()
        {
            return View(await this.materials.AllTapesAsync());
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

        public async Task<IActionResult> EditTape(int id)
        {
            var material = await this.materials.GetTapeByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<BaseMaterialViewModel>(material);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTape(int id, BaseMaterialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditTapeAsync(
                id,
                model.Date,
                model.Price,
                model.SafetyMargin);

            return RedirectToAction(nameof(AllTape));
        }

        public async Task<IActionResult> DeleteTape(int id)
        {
            var material = await this.materials.GetTapeByIdAsync(id);

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
            var material = await this.materials.GetTapeByIdAsync(id);

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

        #region Service Prices

        public async Task<IActionResult> AllService()
        {
            return View(await this.materials.AllServicesAsync());
        }

        public IActionResult AddService() => View(new ServicePriceViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddService(ServicePriceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddServiceAsync(
                model.Date,
                model.PlateExposing,
                model.MachineSetup,
                model.Impression,
                model.Packing);

            return RedirectToAction(nameof(AllService));
        }

        public async Task<IActionResult> EditService(int id)
        {
            var servicePrice = await this.materials.GetServiceByIdAsync(id);

            if (servicePrice == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<ServicePriceViewModel>(servicePrice);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditService(int id, ServicePriceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditServiceAsync(
                id,
                model.Date,
                model.PlateExposing,
                model.MachineSetup,
                model.Impression,
                model.Packing);

            return RedirectToAction(nameof(AllService));
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var servicePrice = await this.materials.GetServiceByIdAsync(id);

            if (servicePrice == null)
            {
                return NotFound();
            }

            return View(new ServicePriceDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyService(int id)
        {
            var servicePrice = await this.materials.GetServiceByIdAsync(id);

            if (servicePrice == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeleteServiceAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllService));
            }
        }

        #endregion

        #region Material Consumption

        public async Task<IActionResult> AllConsumption()
        {
            return View(await this.materials.AllConsumptionsAsync());
        }

        public IActionResult AddConsumption() => View(new MaterialConsumptionViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddConsumption(MaterialConsumptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddConsumptionAsync(
                model.Date,
                model.PageWidth,
                model.PageHeight,
                model.Foil,
                model.Tape,
                model.Wischwasser,
                model.InkBlack,
                model.InkColor,
                model.PlateDeveloper);

            return RedirectToAction(nameof(AllConsumption));
        }

        public async Task<IActionResult> EditConsumption(int id)
        {
            var consumptionPrice = await this.materials.GetConsumptionByIdAsync(id);

            if (consumptionPrice == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<MaterialConsumptionViewModel>(consumptionPrice);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditConsumption(int id, MaterialConsumptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditConsumptionAsync(
                id,
                model.Date,
                model.PageWidth,
                model.PageHeight,
                model.Foil,
                model.Tape,
                model.Wischwasser,
                model.InkBlack,
                model.InkColor,
                model.PlateDeveloper);

            return RedirectToAction(nameof(AllConsumption));
        }

        public async Task<IActionResult> DeleteConsumption(int id)
        {
            var consumptionPrice = await this.materials.GetConsumptionByIdAsync(id);

            if (consumptionPrice == null)
            {
                return NotFound();
            }

            return View(new MaterialConsumptionDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyConsumption(int id)
        {
            var consumptionPrice = await this.materials.GetConsumptionByIdAsync(id);

            if (consumptionPrice == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeleteConsumptionAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllConsumption));
            }
        }

        #endregion

        #region Paper Waste

        public async Task<IActionResult> AllPaperWaste()
        {
            return View(await this.materials.AllPaperWastesAsync());
        }

        public IActionResult AddPaperWaste() => View(new PaperWasteViewModel()
        {
            Date = DateTime.UtcNow
        });

        [HttpPost]
        public async Task<IActionResult> AddPaperWaste(PaperWasteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.AddPaperWasteAsync(
                model.Date,
                model.CoreWaste,
                model.PrintingWaste,
                model.Key1,
                model.Value1,
                model.Key2,
                model.Value2,
                model.Key3,
                model.Value3,
                model.Key4,
                model.Value4,
                model.Key5,
                model.Value5);

            return RedirectToAction(nameof(AllPaperWaste));
        }

        public async Task<IActionResult> EditPaperWaste(int id)
        {
            var paperWaste = await this.materials.GetPaperWasteByIdAsync(id);

            if (paperWaste == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<PaperWasteViewModel>(paperWaste);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPaperWaste(int id, PaperWasteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.materials.EditPaperWasteAsync(
                id,
                model.Date,
                model.CoreWaste,
                model.PrintingWaste,
                model.Key1,
                model.Value1,
                model.Key2,
                model.Value2,
                model.Key3,
                model.Value3,
                model.Key4,
                model.Value4,
                model.Key5,
                model.Value5);

            return RedirectToAction(nameof(AllPaperWaste));
        }

        public async Task<IActionResult> DeletePaperWaste(int id)
        {
            var paperWaste = await this.materials.GetPaperWasteByIdAsync(id);

            if (paperWaste == null)
            {
                return NotFound();
            }

            return View(new PaperWasteDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyPaperWaste(int id)
        {
            var paperWaste = await this.materials.GetPaperWasteByIdAsync(id);

            if (paperWaste == null)
            {
                return NotFound();
            }
            else
            {
                await this.materials.DeletePaperWasteAsync(id);

                this.TempData["SuccessMessage"] = $"Selected record was successfuly deleted!";

                return RedirectToAction(nameof(AllPaperWaste));
            }
        }

        #endregion

        private async Task<IList<SelectListItem>> GetAllPaperTypesAsync()
        {
            var allPaperTypes = await this.materials.AllPaperTypesAsync();

            var result = allPaperTypes
             .Where(pt => pt.IsActive)
             .Select(pt => new SelectListItem()
             {
                 Text = $"{pt.Name} {pt.Grammage} гр.",
                 Value = pt.Id.ToString()
             })
             .OrderBy(r => r.Text)
             .ToList();

            return result;
        }
    }
}
