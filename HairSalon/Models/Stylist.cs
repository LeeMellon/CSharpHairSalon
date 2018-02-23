using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
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

      public int GetId()
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
          bool idEquality = (this.GetId() == newStylist.GetId());
          bool nameEquality = (this.GetStylistName() == newStylist.GetStylistName());
          bool chairEquality = (this.GetStylstChair() == newStylist.GetStylstChair());
          return (idEquality && nameEquality && chairEquality);
        }
      }

      public override int GetHashCode()
      {
        return this.GetId().GetHashCode();
      }

      public static void DeleteAllStylists()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylists;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      public static List<Stylist> GetAllStylists()
      {
        List<Stylist> allStylists = new List<Stylist>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int stylistId = rdr.GetInt32(0);
          string stylistName = rdr.GetString(1);
          int stylistChair = rdr.GetInt32(2);
          Stylist newStylist = new Stylist(stylistName, stylistChair, stylistId);
          allStylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allStylists;
      }

      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO stylists (name, chair) VALUES (@name, @chair);";

        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@name";
        name.Value = this._name;
        cmd.Parameters.Add(name);

        MySqlParameter chair = new MySqlParameter();
        chair.ParameterName = "@chair";
        chair.Value = this._chair;
        cmd.Parameters.Add(chair);

        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;

         conn.Close();
         if (conn != null)
         {
           conn.Dispose();
        }
      }

    }

}
