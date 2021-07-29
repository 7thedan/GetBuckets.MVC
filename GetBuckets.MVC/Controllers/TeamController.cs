
using GetBuckets.Models.Team;
using GetGuckets.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetBuckets.MVC.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamServices(userID);
            var model = service.GetTeams();

            return View(model);
        }

        public ActionResult Create()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            ViewBag.PlayerList = new PlayerServices(userID).GetPlayers();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTeamService();

            if (service.CreateTeam(model))
            {
                TempData["SaveResult"] = "Your tteam was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Team could not be created");

            return View(model);
        }
        private TeamServices CreateTeamService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamServices(userID);

            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamByID(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeamID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateTeamService();
            if (service.UpdateTeam(model))
            {
                TempData["SaveResult"] = "Your team was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your team could not be updated");
            return View();
        }
        public ActionResult Edit(int id)
        {
            var service = CreateTeamService();
            var detail = service.GetTeamByID(id);
            var model =
                    new TeamEdit
                    {
                        TeamID = detail.TeamID,
                        TeamName = detail.TeamName,
                        LocationName = detail.LocationName
                    };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTeamService();

            service.DeleteTeam(id);

            TempData["SaveResult"] = "Your note was deleted";
            return RedirectToAction("Index");
        }
    }
}