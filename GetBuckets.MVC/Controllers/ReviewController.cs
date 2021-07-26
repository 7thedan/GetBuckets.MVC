using GetBuckets.Models.Review;
using GetGuckets.Services;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate review)
        {
            if (ModelState.IsValid)
            {

            }
            return View(review);
        }
    }
}