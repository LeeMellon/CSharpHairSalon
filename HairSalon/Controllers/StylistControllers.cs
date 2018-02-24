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
        Stylist newStylist = new Stylist (Request.Form["new-stylist"], Convert.ToInt32(Request.Form["stylist-chair"]));
        newStylist.Save();
        List<Stylist> allStylist = Stylist.GetAllStylists();
        return RedirectToAction("Index", allStylist);
      }

      [HttpGet("/stylist/{id}/client/new")]
      public ActionResult StylistAddClient(int id)
      {
        Stylist thisStylist = Stylist.Find(id);
        return RedirectToAction("ClientCreator","client", thisStylist);
      }

      [HttpGet("/stylist/{id}")]
        public ActionResult StylistDetails(int id)
        {
          Stylist thisStylist = Stylist.Find(id);
          List<Client> stylistClients = Client.GetClientsByStylistId(id);
          Dictionary<string, object> StylistClientDict = new Dictionary <string, object>();
          StylistClientDict.Add("stylistName", thisStylist);
          StylistClientDict.Add("stylistClients", stylistClients);
          return View(StylistClientDict);
        }
        [HttpPost("/stylist/{id}/delete_stylist")]
        public ActionResult StylistDelete(int id)
        {
         Client.DeleteAllClientsByStylist(id);
         Stylist.DeleteStylist(id);
         List<Stylist> allStylists = Stylist.GetAllStylists();
         return View("index", allStylists);
       }
    }
}
