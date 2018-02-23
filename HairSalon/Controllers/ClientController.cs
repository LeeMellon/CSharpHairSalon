using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairStylist.Controllers
{
    public class Client : Controller
    {
      [HttpGet("/")]
          public ActionResult Index()
          {

            return View();

          }
          [HttpPost("/")]
          public ActionResult Result()
          {

            return View();
          }


    }
}
