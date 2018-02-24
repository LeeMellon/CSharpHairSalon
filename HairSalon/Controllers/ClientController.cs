using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
      [HttpGet("/client/{id}/new")]
          public ActionResult CreateForm(int id)
          {
            Stylist thisStylist = Stylist.Find(id);
              return View(thisStylist);
          }

          [HttpPost("/client/new")]
          public ActionResult Create()
          {
            int stylistId = Convert.ToInt32(Request.Form["stylist_id"]);
            string firstName = Request.Form["new-client-first"];
            string lastName = Request.Form["new-client-last"];
            long number = Convert.ToInt64(Request.Form["new-client-number"]);
            string email = Request.Form["new-client-email"];
            Client newClient = new Client (firstName, lastName, number, email, stylistId);
            newClient.Save();
            return RedirectToAction("Index","stylist");
          }

          [HttpGet("/client/{id}/update")]
          public ActionResult UpdateForm(int id)
          {
            Client thisClient = Client.Find(id);
            List<Stylist> allStylists = Stylist.GetAllStylists();
            Dictionary<string, object> clientStyistsDict = new Dictionary<string, object>();
            clientStyistsDict.Add("stylist", allStylists);
            clientStyistsDict.Add("client", thisClient);
            return View(clientStyistsDict);
          }

          [HttpPost("/client/{id}/update")]
          public ActionResult Update(int id)
          {
            Client thisClient = Client.Find(id);
            thisClient.EditClient(Request.Form["firstName"], Request.Form["lastName"], Convert.ToInt64(Request.Form["number"]), Request.Form["email"], Convert.ToInt32(Request.Form["stylist_id"]));
            return RedirectToAction("index", "stylist");
          }

          [HttpPost("/client/{id}/delete_all")]
          public ActionResult DeleteAll(int id)
          {
              Client.DeleteAllClientsByStylist(id);
              return RedirectToAction("index", "stylist");
          }

          [HttpPost("/client/{id}/delete")]
          public ActionResult DeleteClient(int id)
          {
            Client thisClient = Client.Find(id);
            int stylistId = thisClient.GetStylistId();
            Client.DeleteClient(id);
            return RedirectToAction("StylistDetails", "stylist", new {Id = thisClient.GetStylistId()});
          }

    }
}
