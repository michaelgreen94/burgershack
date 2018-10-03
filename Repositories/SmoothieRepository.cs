using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class SmoothieRepository
  {
    private IDbConnection _db;
    public SmoothieRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL BURGERS
    public IEnumerable<Smoothie> GetAll()
    {
      return _db.Query<Smoothie>("SELECT * FROM smoothies;");
    }

    //GET smoothie BY ID
    public Smoothie GetByID(int id)
    {
      return _db.Query<Smoothie>("SELECT * FROM smoothies WHERE id = @id;", new { id }).FirstOrDefault();
    }

    //CREATE smoothie
    public Smoothie Create(Smoothie smoothie)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO smoothies (name, description, price)
      Values (@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();", smoothie
      );
      smoothie.Id = id;
      return smoothie;
    }

    //UPDATE smoothie
    public Smoothie Update(Smoothie smoothie)
    {
      _db.Execute(@"
      UPDATE smoothies SET (name, description, price)
      VALUES (@Name, @Description, @Price)
      WHERE id = @Id;", smoothie);
      return smoothie;
    }

    //DELETE smoothie
    public Smoothie Delete(Smoothie smoothie)
    {
      _db.Execute("DELETE FROM smoothies WHERE id = @Id");
      return smoothie;
    }

    //DELETES A smoothie BY ITS ID
    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM smoothies WHERE id = @id", new { id });
    }

  }
}