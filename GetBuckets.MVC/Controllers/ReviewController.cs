using GetBuckets.Models.Review;
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
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewServices(userID);
            var model = service.GetReviews();

            return View(model);
        }

        public ActionResult Create()
        {

            var userID = Guid.Parse(User.Identity.GetUserId()); //go get the userid. 
            ViewBag.LocationList = new LocationServices(userID).GetLocations();
            ViewBag.PlayerList = new PlayerServices(userID).GetPlayers();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReviewService();

            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Your location was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Review could not be created");

            return View(model);
        }

        private ReviewServices CreateReviewService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewServices(userID);

            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewByID(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReviewID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateReviewService();
            if (service.UpdateReview(model))

                if (model.ReviewID != id)
                {
                    ModelState.AddModelError("", "ID Mismatch");
                    return View(model);
                }

            ModelState.AddModelError("", "Your review could not be updated");
            return View();
        }
        public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetReviewByID(id);
            var model =
                    new ReviewEdit
                    {
                        LocationName = detail.LocationName,
                        Address = detail.Address,
                        Comment = detail.Comment,
                        IsRecommended = detail.IsRecommended,
                        LocationRating = detail.LocationRating,

                    };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewByID(id);

            return View(model);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateReviewService();

            service.DeleteReview(id);

            TempData["SaveResult"] = "Your note was deleted";
            return RedirectToAction("Index");
        }
        
    }
}