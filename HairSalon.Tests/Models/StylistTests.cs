using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAllStylists();
    }

    public void StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=ian_goodrich_test;";
    }

    [TestMethod]
    public void GetsAndSets_AllGettersAndSetters_Values()
    {
      //arrange
      Stylist newStylist = new Stylist("Kimberly", 3, 1);
      //action
      string stylistName = newStylist.GetStylistName();
      int stylistChair = newStylist.GetStylstChair();
      int stylistId = newStylist.StylistGetId();
      //assert
      Assert.AreEqual(stylistName, "Kimberly");
      Assert.AreEqual(stylistChair, 3);
      Assert.AreEqual(stylistId, 1);

    }
  }
}
