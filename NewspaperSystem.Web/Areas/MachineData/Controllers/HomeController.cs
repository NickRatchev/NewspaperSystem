namespace NewspaperSystem.Web.Areas.MachineData.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;
    using NewspaperSystem.Services.MachineData;

    [Area("MachineData")]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class HomeController : Controller
    {
        private readonly IMachineDataService machineDatas;

        public HomeController(IMachineDataService machineDatas)
        {
            this.machineDatas = machineDatas;
        }

        #region Web Sizes

        public async Task<IActionResult> AllWebSizes()
        {
            return View(await this.machineDatas.AllWebSizesAsync());
        }

        public IActionResult AddWebSize() => View(new WebSizeViewModel());

        [HttpPost]
        public async Task<IActionResult> AddWebSize(WebSizeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.machineDatas.AddWebSizeAsync(
                model.WebName,
                model.WebWidth);

            return RedirectToAction(nameof(AllWebSizes));
        }

        public async Task<IActionResult> EditWebSize(int id)
        {
            var WebSize = await this.machineDatas.GetWebSizeByIdAsync(id);

            if (WebSize == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<WebSizeViewModel>(WebSize);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditWebSize(int id, WebSizeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await this.machineDatas.EditWebSizeAsync(
                id,
                model.WebName,
                model.WebWidth);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(AllWebSizes));
        }

        public async Task<IActionResult> DeleteWebSize(int id)
        {
            var WebSize = await this.machineDatas.GetWebSizeByIdAsync(id);

            if (WebSize == null)
            {
                return NotFound();
            }

            return View(new WebSizeDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyWebSize(int id)
        {
            var WebSize = await this.machineDatas.GetWebSizeByIdAsync(id);

            var WebSizeIsUsed = await this.machineDatas.WebSizeIsUsedAsync(id);

            if (WebSizeIsUsed)
            {
                this.TempData["SuccessMessage"] =
                    $"WebSize \"{WebSize.WebName}\" is used and cannot be deleted!";

                return RedirectToAction(nameof(AllWebSizes));
            }

            var success = await this.machineDatas.DeleteWebSizeAsync(id);

            if (!success)
            {
                return NotFound();
            }

            this.TempData["SuccessMessage"] =
                $"WebSize \"{WebSize.WebName}\" was deleted!";

            return RedirectToAction(nameof(AllWebSizes));
        }

        #endregion

        #region Machine Data

        public async Task<IActionResult> AllMachineData()
        {
            return View(await this.machineDatas.AllMachineDatasAsync());
        }

        public async Task<IActionResult> AddMachineData()
        {
            var webSizes = await GetAllWebSizesAsync();

            return View(new MachineDataViewModel()
            {
                WebSizes = webSizes
            });
        }


        [HttpPost]
        public async Task<IActionResult> AddMachineData(MachineDataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var webSizes = await GetAllWebSizesAsync();

                model.WebSizes = webSizes;

                return View(model);
            }

            await this.machineDatas.AddMachineDataAsync(
                model.NumberOfPages,
                model.M1NumberOfPages,
                model.M2NumberOfPages,
                model.Web1Id,
                model.Web2Id,
                model.ProductionFactor,
                model.BaseSpeed);

            return RedirectToAction(nameof(AllMachineData));
        }

        public async Task<IActionResult> EditMachineData(int id)
        {
            var machineData = await this.machineDatas.GetMachineDataByIdAsync(id);

            if (machineData == null)
            {
                return NotFound();
            }

            var webSizes = await GetAllWebSizesAsync();

            var model = Mapper.Map<MachineDataViewModel>(machineData);

            model.WebSizes = webSizes;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMachineData(int id, MachineDataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var webSizes = await GetAllWebSizesAsync();

                model.WebSizes = webSizes;

                return View(model);
            }

            var success = await this.machineDatas.EditMachineDataAsync(
                id,
                model.NumberOfPages,
                model.M1NumberOfPages,
                model.M2NumberOfPages,
                model.Web1Id,
                model.Web2Id,
                model.ProductionFactor,
                model.BaseSpeed);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(AllMachineData));
        }

        public async Task<IActionResult> DeleteMachineData(int id)
        {
            var machineData = await this.machineDatas.GetMachineDataByIdAsync(id);

            if (machineData == null)
            {
                return NotFound();
            }

            return View(new MachineDataDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyMachineData(int id)
        {
            var machineData = await this.machineDatas.GetMachineDataByIdAsync(id);

            var machineDataIsUsed = await this.machineDatas.MachineDataIsUsedAsync(id);

            if (machineDataIsUsed)
            {
                this.TempData["SuccessMessage"] =
                    $"This MachineData record is used and cannot be deleted!";

                return RedirectToAction(nameof(AllMachineData));
            }

            var success = await this.machineDatas.DeleteMachineDataAsync(id);

            if (!success)
            {
                return NotFound();
            }

            this.TempData["SuccessMessage"] =
                $"The MachineData record was deleted!";

            return RedirectToAction(nameof(AllMachineData));
        }

        #endregion

        private async Task<IList<SelectListItem>> GetAllWebSizesAsync()
        {
            var allWebSizes = await this.machineDatas
                .AllWebSizesAsync();

            var result = allWebSizes
                .Select(ws => new SelectListItem()
                {
                    Text = ws.WebName,
                    Value = ws.Id.ToString()
                })
                .ToList();

            return result;
        }
    }
}
