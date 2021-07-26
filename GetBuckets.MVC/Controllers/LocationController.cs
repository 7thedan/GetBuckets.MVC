using GetBuckets.Models.LocationModel;
using GetGuckets.Services;
using Microsoft.AspNet.Identity;
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
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId()); //go get the userid. 
            var service = new LocationServices(userID); //start the service. If the user is valid.
            var model = service.GetLocations(); //the model is all locations. 

            return View(model); //return model on line 21 as you're index. 
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            //
            if (!ModelState.IsValid) return View(model);

            var service = CreateLocationService();

            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Your location was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Location could not be created.");

            return View(model);
        }
        private LocationServices CreateLocationService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationServices(userID);

            return service;
        }

        public ActionResult Details(int id)
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

            if(model.LocationID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateLocationService();
            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "Your location was updated.";
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
                        LocationName = detail.LocationName,
                        Street = detail.Street,
                        City = detail.City,
                        State = detail.State,
                        ZipCode = detail.ZipCode,
                        Open = detail.Open,
                        Closed = detail.Closed,
                        HoursOfOperation = detail.HoursOfOperation,
                        Indoor = detail.Indoor,
                        Outdoor = detail.Outdoor,
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
        public ActionResult DeleteLocation(int id)
        {
            var service = CreateLocationService();
            service.DeleteLocation(id);

            TempData["SaveResult"] = "Your note was deleted";
            return RedirectToAction("Index");
        }
    }
}