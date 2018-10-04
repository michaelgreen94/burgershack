using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class UserRepository
  {
    //Never Get All!!!
    IDbConnection _db;
    // SaltRevision SALT = SaltRevision.Revision2X;


    //Register (C)
    public User Register(UserRegistration creds)
    {
      //generate user ID
      //hash the password
      var id = Guid.NewGuid().ToString();
      string hash = BCrypt.Net.BCrypt.HashPassword(creds.Password);

      int success = _db.Execute(@"
      INSERT INTO users (id, username, email, hash)
      VALUES(@id, @username, @email, @hash);
      ", new
      {
        id,
        username = creds.Username,
        email = creds.Email,
        hash
      });
      if (success != 1)
      {
        return null;
      }
      return new User()
      {
        Username = creds.Username,
        Email = creds.Email,
        Hash = null,
        Id = id
      };
    }

    //Login (R)
    public User Login(UserLogin creds)
    {
      User user = _db.Query<User>(@"
      SELECT * FROM users WHERE email = @Email
      ", creds).FirstOrDefault();

      if (user == null) { return null; }

      bool validPass = BCrypt.Net.BCrypt.Verify(creds.Password, user.Hash);

      if (!validPass) { return null; }
      user.Hash = null;
      return user;

    }

    internal User GetUserById(string id)
    {
      User user = _db.Query<User>(@"
      SELECT * FROM users WHERE id = @id
      ", new { id }).FirstOrDefault();
      if (user != null)
      {
        user.Hash = null;
      }
      return user;
    }

    //Update (U)
    //Change Pass (U)
    //Delete (D)

    public UserRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}