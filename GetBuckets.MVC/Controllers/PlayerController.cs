using GetBuckets.Models.PlayerModel;
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
            var player = new PlayerListItems[0];
            return View(player);
           
        }
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerCreate player)
        {
            if (ModelState.IsValid)
            {

            }
            return View(player); //156 var result = await UserManger.CreatedAsync(user, model.Password)
        }
    }
}