using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
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
