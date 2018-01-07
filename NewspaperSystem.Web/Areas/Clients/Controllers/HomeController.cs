﻿namespace NewspaperSystem.Web.Areas.Clients.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;
    using NewspaperSystem.Services.Clients;

    [Area("Clients")]
    [Authorize(Roles = 
        WebConstants.AdministratorRole + "," + 
        WebConstants.RegularUserRole)]

    public class HomeController : Controller
    {
        private readonly IClientService clients;

        public HomeController(IClientService clients)
        {
            this.clients = clients;
        }

        #region Town

        public async Task<IActionResult> AllTowns()
        {
            return View(await this.clients.AllTownsAsync());
        }

        public IActionResult AddTown() => View(new TownViewModel());

        [HttpPost]
        public async Task<IActionResult> AddTown(TownViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.clients.AddTownAsync(
                model.Name);

            return RedirectToAction(nameof(AllTowns));
        }

        public async Task<IActionResult> EditTown(int id)
        {
            var town = await this.clients.GetTownByIdAsync(id);

            if (town == null)
            {
                return NotFound();
            }

            var model = Mapper.Map<TownViewModel>(town);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTown(int id, TownViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var town = new TownViewModel()
            {
                Name = model.Name
            };

            var success = await this.clients.EditTownAsync(
                id,
                model.Name);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(AllTowns));
        }

        public async Task<IActionResult> DeleteTown(int id)
        {
            var town = await this.clients.GetTownByIdAsync(id);

            if (town == null)
            {
                return NotFound();
            }

            return View(new TownDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyTown(int id)
        {
            var town = await this.clients.GetTownByIdAsync(id);

            var townIsUsed = await this.clients.TownIsUsedAsync(id);

            if (townIsUsed)
            {
                this.TempData["SuccessMessage"] =
                    $"Town \"{town.Name}\" is used and cannot be deleted!";

                return RedirectToAction(nameof(AllTowns));
            }

            var success = await this.clients.DeleteTownAsync(id);

            if (!success)
            {
                return NotFound();
            }

            this.TempData["SuccessMessage"] =
                $"Town \"{town.Name}\" was deleted!";

            return RedirectToAction(nameof(AllTowns));
        }

        #endregion

        #region Client

        public async Task<IActionResult> AllClient()
        {
            return View(await this.clients.AllCliensAsync());
        }

        public async Task<IActionResult> AddClient()
        {
            var towns = await GetAllTownsAsync();

            return View(new ClientViewModel()
            {
                Towns = towns
            });
        }


        [HttpPost]
        public async Task<IActionResult> AddClient(ClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var towns = await GetAllTownsAsync();

                model.Towns = towns;

                return View(model);
            }

            await this.clients.AddClientAsync(
                model.CompanyName,
                model.VatNumber,
                model.Address,
                model.ContactPerson,
                model.Phone,
                model.Email,
                model.IsActive,
                model.TownId);

            return RedirectToAction(nameof(AllClient));
        }

        public async Task<IActionResult> EditClient(int id)
        {
            var client = await this.clients.GetClientByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            var towns = await GetAllTownsAsync();
            var model = Mapper.Map<ClientViewModel>(client);

            model.Towns = towns;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditClient(int id, ClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var towns = await GetAllTownsAsync();

                model.Towns = towns;

                return View(model);
            }

            var success = await this.clients.EditClientAsync(
                id,
                model.CompanyName,
                model.VatNumber,
                model.Address,
                model.ContactPerson,
                model.Phone,
                model.Email,
                model.IsActive,
                model.TownId);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(AllClient));
        }

        public async Task<IActionResult> DeleteClient(int id)
        {
            var material = await this.clients.GetClientByIdAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return View(new ClientDeleteViewModel()
            {
                Id = id
            });
        }

        public async Task<IActionResult> DestroyClient(int id)
        {
            var client = await this.clients.GetClientByIdAsync(id);

            var clientIsUsed = await this.clients.ClientIsUsedAsync(id);

            if (clientIsUsed)
            {
                this.TempData["SuccessMessage"] =
                    $"Client \"{client.CompanyName}\" is used and cannot be deleted!";

                return RedirectToAction(nameof(AllClient));
            }

            var success = await this.clients.DeleteClientAsync(id);

            if (!success)
            {
                return NotFound();
            }

            this.TempData["SuccessMessage"] =
                $"Town \"{client.CompanyName}\" was deleted!";

            return RedirectToAction(nameof(AllClient));
        }

        #endregion

        private async Task<IList<SelectListItem>> GetAllTownsAsync()
        {
            var allTowns = await this.clients.AllTownsAsync();

            var result = allTowns
                .Select(pt => new SelectListItem()
                {
                    Text = pt.Name,
                    Value = pt.Id.ToString()
                })
                .OrderBy(r => r.Text)
                .ToList();

            return result;
        }
    }
}