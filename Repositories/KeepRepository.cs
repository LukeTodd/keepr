using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }
    public IEnumerable<Keep> GetByUserId(string UserId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userid = @UserId", new { UserId });
    }
    public Keep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @Id", new { Id });
    }
    public Keep CreateKeep(Keep keep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description, img, isprivate, views, shares, keeps, userid)
        VALUEs(@Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps, @UserId);
        SELECT LAST_INSERT_ID();
        ", keep);
        keep.Id = id;
        return keep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
    public bool Delete(int Id)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @Id", new { Id });
      return success > 0;
    }
  }
}