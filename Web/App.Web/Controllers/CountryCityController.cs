using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace App.Web.Controllers
{
    [Authorize(Roles = Roles.SuperAdmin)]
    public class CountryCityController : BaseController
    {
        public CountryCityController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager,
           IConfiguration _config, IMediator _mediator, IMapper _mapper) : base(_userManager, _signInManager, _roleManager, _config, _mediator, _mapper)
        { }

        #region Country
        [HttpGet]
        [Authorize("Permission-CountryList")]
        public async Task<IActionResult> CountryList()
        {
            var query = new GetCountryListQuery();
            var Countries = await _mediator.Send(query);
            return View(Countries);
        }

        [HttpGet]
        [Authorize("Permission-AddCountry")]
        public async Task<IActionResult> AddCountry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(AddCountryRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            model.CreatedById = LoggedInuser.Id;
            model.CreatedDate = DateTime.Now;

            var CountryId = await _mediator.Send(model);
            TempData["Message"] = 1;

            return View(model);

        }

        [HttpGet]
        [Authorize("Permission-EditCountry")]
        public async Task<IActionResult> EditCountry(int id)
        {
            var query = new GetCountryListQuery();
            var country = await _mediator.Send(query);

            return View(_mapper.Map<UpdateCountryRequest>(country.FirstOrDefault(i => i.Id == id)));
        }

        [HttpPost]
        public async Task<IActionResult> EditCountry(UpdateCountryRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            model.LastModifiedById = LoggedInuser.Id;
            model.LastModifiedDate = DateTime.Now;

            await _mediator.Send(model);
            TempData["Message"] = 1;

            return RedirectToAction(nameof(CountryList));

        }

        [HttpPost]
        [Authorize("Permission-DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

            var command = new DeleteCountryRequest() { Id = id };
            await _mediator.Send(command);

            TempData["Message"] = 1;

            return RedirectToAction(nameof(CountryList));

        }
        #endregion

        #region City
        [HttpGet]
        [Authorize("Permission-CityList")]
        public async Task<IActionResult> CityList()
        {
            var query = new GetCityListQuery();
            var cities = await _mediator.Send(query);
            return View(cities);
        }

        [HttpGet]
        [Authorize("Permission-AddCity")]
        public async Task<IActionResult> AddCity()
        {
            var query = new GetCountryListQuery();
            var Countries = await _mediator.Send(query);

            ViewData["Countries"] = new SelectList(Countries, "Id", "NameEnglish");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(AddCityRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            model.CreatedById = LoggedInuser.Id;
            model.CreatedDate = DateTime.Now;

            var CountryId = await _mediator.Send(model);
            TempData["Message"] = 1;

            return View(model);

        }

        [HttpGet]
        [Authorize("Permission-EditCity")]
        public async Task<IActionResult> EditCity(int id)
        {
            var query = new GetCityListQuery();
            var city = await _mediator.Send(query);

            var queryCountries = new GetCountryListQuery();
            var Countries = await _mediator.Send(queryCountries);
            ViewData["Countries"] = new SelectList(Countries, "Id", "NameEnglish");

            return View(_mapper.Map<UpdateCityRequest>(city.FirstOrDefault(i => i.Id == id)));
        }

        [HttpPost]
        public async Task<IActionResult> EditCity(UpdateCityRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            model.LastModifiedById = LoggedInuser.Id;
            model.LastModifiedDate = DateTime.Now;

            await _mediator.Send(model);
            TempData["Message"] = 1;

            return RedirectToAction(nameof(CityList));

        }

        [HttpPost]
        [Authorize("Permission-DeleteCity")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

            var command = new DeleteCityRequest() { Id = id };
            await _mediator.Send(command);

            TempData["Message"] = 1;

            return RedirectToAction(nameof(CityList));

        }
        #endregion
    }
}
