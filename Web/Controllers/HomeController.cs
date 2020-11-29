using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Queries.Messages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApplicationDbContext _context;

        public HomeController(IApplicationDbContext context)
        {
            _context = context;        
        }

        [Authorize]
        public async Task<IActionResult> Index(FindAllCostumersQuery query)
        {
            if (!User.IsAdmin())
            {
                query.UserId = User.GetId();
            }

            var customers = await Mediator.Send(query);

            var genders = await FindAllGenders();
            var cities = await FindAllCities();
            var regions = await FindAllRegions();
            var classifications = await FindAllClassifications();
            var users = await FindAllUsers();

            ViewBag.Name = query.Name;
            ViewBag.LastPurchaseStart = query.LastPurchaseStart;
            ViewBag.LastPurchaseEnd = query.LastPurchaseEnd;

            ViewBag.Genders = new SelectList(genders, "Id", "Name", query.GenderId);
            ViewBag.Cities = new SelectList(cities, "Id", "Name", query.CityId);
            ViewBag.Regions = new SelectList(regions, "Id", "Name", query.RegionId);
            ViewBag.Classifications = new SelectList(classifications, "Id", "Name", query.ClassificationId);
            ViewBag.Users = new SelectList(users, "Id", "Name", query.UserId);

            return View(customers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Lists

        private async Task<IList<GenderDTO>> FindAllGenders()
        {
            var items = await Mediator.Send(new FindAllGendersQuery());
            items.Insert(0, new GenderDTO { });

            return items;
        }

        private async Task<IList<CityDTO>> FindAllCities()
        {
            var items = await Mediator.Send(new FindAllCitiesQuery());
            items.Insert(0, new CityDTO { });

            return items;
        }

        private async Task<IList<RegionDTO>> FindAllRegions()
        {
            var items = await Mediator.Send(new FindAllRegionsQuery());
            items.Insert(0, new RegionDTO { });

            return items;
        }

        private async Task<IList<ClassificationDTO>> FindAllClassifications()
        {
            var items = await Mediator.Send(new FindAllClassificationsQuery());
            items.Insert(0, new ClassificationDTO { });

            return items;
        }

        private async Task<IList<UserDTO>> FindAllUsers()
        {
            var items = await Mediator.Send(new FindAllUsersQuery());
            items.Insert(0, new UserDTO { });

            return items;
        }

        #endregion
    }
}
