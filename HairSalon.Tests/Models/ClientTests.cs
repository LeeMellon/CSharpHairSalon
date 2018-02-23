using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAllClients();
    }

    public void ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=ian_goodrich_test;";
    }

    [TestMethod]
    public void GetsAndSets_AllGettersAndSetters_Values()
    {
      //arrange
      Client newClient = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org", 1, 3);
      //action
      string clientFirstName = newClient.GetFirstName();
      string clientLastName = newClient.GetLastName();
      long clientNumber = newClient.GetNumber();
      string clientEmail = newClient.GetEmail();
      int clientStylistId = newClient.GetStylistId();
      int clientId = newClient.GetId();
      //assert
      Assert.AreEqual(clientFirstName, "Franz");
      Assert.AreEqual(clientLastName, "Franzia");
      Assert.AreEqual(clientNumber, 5031112222);
      Assert.AreEqual(clientEmail, "franz@franzia.org");
      Assert.AreEqual(clientStylistId, 1);
      Assert.AreEqual(clientId, 3);
    }

    [TestMethod]
    public void GetAllClients_ReturnClientList_List()
    {
      //arrange
      List<Client> clientList = new List<Client>{};
      Client newClient1 = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org", 1, 3);
      Client newClient2 = new Client("Hanz", "Hanzia", 5032223333, "hanz@hanzia.org", 2, 2);
      clientList.Add(newClient1);
      clientList.Add(newClient2);
      //action
      newClient1.Save();
      newClient2.Save();
      List<Client> testList = Client.GetAllClients();
      //assert
      CollectionAssert.AreEqual(testList, clientList);
    }
  }
}
