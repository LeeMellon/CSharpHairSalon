using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        List<Stylist> allStylists = Stylist.GetAllStylists();
        return View(allStylists);
      }

      [HttpGet("/stylist/new")]
        public ActionResult StylistCreator()
        {
            return View();
        }


        [HttpPost("/stylist/create")]
      public ActionResult CreateStylist()
      {
        Stylist newStylist = new Stylist (Request.Form["new-stylist"]);
        newStylist.Save();
        List<Stylist> allStylist = Stylist.GetAll();
        return RedirectToAction("Index", allStylist);
      }


    }
}
