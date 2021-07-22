using GetBuckets.Models.PlayerModel;
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
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerServices(userID);
            var model = service.GetPlayers();

            return View(model);
           
        }
        public ActionResult Create()
        {
            return View();
        }

        //team to player many to many
        //one to many location and review. 
        //location is child but it's a one to one location. 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlayerService();

            if (service.CreatePlayer(model))
            {
                ViewBag.SaveResult = "Your player was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Player could not be created.");

            return View(model);

            /*  return View(player);*/ //156 var result = await UserManger.CreatedAsync(user, model.Password)
        }

        private PlayerServices PlayerServices()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerServices(userID);
            return service;
        }

        private PlayerServices CreatePlayerService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerServices(userID);
            return service;
        }
        public ActionResult Detail(int id)
        {
            var svc = CreatePlayerService();
            var model = svc.GetPlayerByID(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlayerID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlayerService();
            if (service.UpdatePlayer(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated");
            return View();
        }
        public ActionResult Edit(int id)
        {
            var service = CreatePlayerService();
            var detail = service.GetPlayerByID(id);
            var model =
                    new PlayerEdit
                    {
                        PlayerID = detail.PlayerID,
                        PlayerEmail = detail.PlayerEmail,
                        Height = detail.Height,
                        Skill = detail.Skill,
                        Position = detail.Position,
                        Location = detail.Location,
                        Indoor = detail.Indoor,
                        Outdoor = detail.Outdoor
                    };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlayerService();
            var model = svc.GetPlayerByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlayerService();

            service.DeletePlayer(id);

            TempData["SaveResult"] = "Your note was deleted";
            return RedirectToAction("Index");
        }

    }
}