using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;


namespace HairSalon.Models
{
    public class Client
    {
      private int _id;
      private string _nameFirst;
      private string _nameLast;
      private int _number;
      private string _email;
      private int _stylistId;

      public Client (string firstName, string lastName, int number, string email, int stylistId, int id = 0)
      {
        _id = id;
        _nameFirst = firstName;
        _nameLast = lastName;
        _number = number;
        _email = email;
        _stylistId = stylistId;
      }

      public void SetFirstName(string firstName)
      {
        _nameFirst = firstName;
      }

      public string GetFirstName()
      {
        return _nameFirst;
      }

      public void SetLastName(string lastName)
      {
        _nameLast = lastName;
      }

      public string GetLastName()
      {
        return _nameLast;
      }

      public void SetNumber(int number)
      {
        _number = number;
      }

      public int GetNumber()
      {
        return _number;
      }

      public void SetEmail(string email)
      {
        _email = email;
      }

      public string GetEmail()
      {
        return _email;
      }

      public void SetStylistId(int stylist_Id)
      {
        _stylistId = stylistId;
      }

      public int GetStylistId()
      {
        return _stylistId;
      }

      public void SetId(int id)
      {
        _id = id;
      }

      public int GetId()
      {
        return _id;
      }

      public override bool Equals(System.Object otherClient)
      {
        if (!(otherClient is Client))
        {
          return false;
        }
        else
        {
          Client newClient = (Client) otherClient;
          bool idEquality = (this.GetId() == newClient.GetId());
          bool firstNameEquality = (this.GetFirstName() == newClient.GetFirstName());
          bool lastNameEquality = (this.GetLastName() == newClient.GetLastName());
          bool numberEquality = (this.GetNumber() == newClient.GetNumber());
          bool emailEquality = (this.GetEmail() == newClient.GetEmail());
          bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
          return (idEquality && firstNameEquality && lastNameEquality && numberEquality && emailEquality && stylistIdEquality);
        }
      }

      public override int GetHashCode()
      {
        return this.GetId().GetHashCode();
      }


    }

}
