using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;


namespace HairSalon.Models
{
    public class Stylist
    {
      private int _id;
      private string _name;
      private int _chair;


      public Stylist (string name, int chair, int id = 0)
      {
        _id = id;
        _name = name;
        _chair = chair;
      }

      public void SetStylistName(string name)
      {
        _name = name;
      }

      public string GetStylistName()
      {
        return _name;
      }

      public void SetStylistChair(int chair)
      {
        _chair = chair;
      }

      public int GetStylstChair()
      {
        return _chair;
      }

      public void StylistSetId(int id)
      {
        _id = id;
      }

      public int StylistGetId()
      {
        return _id;
      }

      public override bool Equals(System.Object otherStylist)
      {
        if (!(otherStylist is Stylist))
        {
          return false;
        }
        else
        {
          Stylist newStylist = (Stylist) otherStylist;
          bool nameEquality = (this.GetStylistName() == newStylist.GetStylistName());
          bool idEquality = (this.StylistGetId() == newStylist.StylistGetId());
          bool chairEquality = (this.GetStylstChair() == newStylist.GetStylstChair());
          return (idEquality && nameEquality && chairEquality);
        }
      }

      public override int GetHashCode()
      {
        return this.GetId().GetHashCode();
      }

    }

}
