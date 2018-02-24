// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using System.Collections.Generic;
// using System;
// using HairSalon.Models;
//
// namespace HairSalon.Tests
// {
//
//   [TestClass]
//   public class StylistTest : IDisposable
//   {
//     public void Dispose()
//     {
//       Stylist.DeleteAllStylists();
//     }
//
//     public void StylistTests()
//     {
//       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=ian_goodrich_test;";
//     }
//
//     [TestMethod]
//     public void GetsAndSets_AllGettersAndSetters_Values()
//     {
//       //arrange
//       Stylist newStylist = new Stylist("Kimberly", 3, 1);
//       //action
//       string stylistName = newStylist.GetStylistName();
//       int stylistChair = newStylist.GetStylstChair();
//       int stylistId = newStylist.GetId();
//       //assert
//       Assert.AreEqual(stylistName, "Kimberly");
//       Assert.AreEqual(stylistChair, 3);
//       Assert.AreEqual(stylistId, 1);
//
//     }
//     [TestMethod]
//     public void GetAllStylists_ReturnStylistList_List()
//     {
//       //arrange
//       List<Stylist> stylistList = new List<Stylist>{};
//       Stylist newStylist1 = new Stylist("Kimberly", 3);
//       Stylist newStylist2 = new Stylist("Berly", 2);
//       stylistList.Add(newStylist1);
//       stylistList.Add(newStylist2);
//       //action
//       newStylist1.Save();
//       newStylist2.Save();
//       List<Stylist> testList = Stylist.GetAllStylists();
//       System.Console.WriteLine(stylistList[1].GetId());
//       System.Console.WriteLine(testList[1].GetId());
//
//       //assert
//       CollectionAssert.AreEqual(testList, stylistList);
//   }
//  }
// }
