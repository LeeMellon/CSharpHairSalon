using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;


namespace HairSalon.Models
{
    public class Client
    {
      private int _id;
      private string _nameFirst;
      private string _nameLast;
      private long _number;
      private string _email;
      private int _stylistId;

      public Client (string firstName, string lastName, long number, string email, int stylistId, int id = 0)
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

      public void SetNumber(long number)
      {
        _number = number;
      }

      public long GetNumber()
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

      public void SetStylistId(int stylistId)
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

      public static void DeleteAllClients()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      public static List<Client> GetAllClients()
      {
        List<Client> allClients = new List<Client>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientId = rdr.GetInt32(0);
          string clientFirstName = rdr.GetString(1);
          string clientLastName = rdr.GetString(2);
          long clientNumber = rdr.GetInt64(3);
          string clientEmail = rdr.GetString(4);
          int clientStylistId = rdr.GetInt32(5);
          Client newClient = new Client(clientFirstName, clientLastName, clientNumber, clientEmail, clientStylistId, clientId);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allClients;
      }

      public void Save()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO clients (first_name, last_name, number, email, stylist_id) VALUES (@firstName, @lastName, @number, @email, @stylistId);";

          MySqlParameter firstName = new MySqlParameter();
          firstName.ParameterName = "@firstName";
          firstName.Value = this._nameFirst;
          cmd.Parameters.Add(firstName);

          MySqlParameter lastName = new MySqlParameter();
          lastName.ParameterName = "@lastName";
          lastName.Value = this._nameLast;
          cmd.Parameters.Add(lastName);

          MySqlParameter number = new MySqlParameter();
          number.ParameterName = "@number";
          number.Value = this._number;
          cmd.Parameters.Add(number);

          MySqlParameter email = new MySqlParameter();
          email.ParameterName = "@email";
          email.Value = this._email;
          cmd.Parameters.Add(email);

          MySqlParameter stylistId = new MySqlParameter();
          stylistId.ParameterName = "@stylistId";
          stylistId.Value = this._stylistId;
          cmd.Parameters.Add(stylistId);

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
