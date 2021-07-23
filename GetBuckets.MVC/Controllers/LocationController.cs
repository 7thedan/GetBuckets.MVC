using GetBuckets.Models.LocationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetBuckets.MVC.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationServices(userID);
            var model = service.GetPlayers();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLocationService();
            {
                ViewBag.SaveResult = "Your location was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Location could not be created");
            return View(location); 
        }

        private LocationServices LocationServices()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationServices(userID);
            return service;
        }
        public ActionResult Detail(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationByID(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.PlayerID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateLocationService();
            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "Your location was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your location could not be updated");
            return View();
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLocationService();
            var detail = service.GetLocationByID(id);
            var model =
                new LocationEdit
                {
                    LocationName = service.LocationName,
                    Street = service.Street,
                    State = service.State,
                    City = service.City,
                    ZipCode = service.ZipCode,
                    Open = service.Open,
                    Closed = service.Closed,
                    HoursOfOperation = service.HoursOfOperation,
                    Memembership = service.Membership,
                    Indoor = service.Indoor,
                    Outdoor = service.Outdoor
                };
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLocationService();

            service.DeleteLocation(id);

            TempData["SaveResult"] = "Your location was deleted";
            return RedirectToAction("Index");
        }
    }
}