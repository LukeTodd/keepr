using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {

    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetAllByUserId(string UserId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userid = @UserId", new { UserId });
    }
    public Vault GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @Id", new { Id });
    }
    public Vault CreateVault(Vault vault)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults (name, description, userId)
        VALUES (@Name, @Description, @UserId);
        SELECT LAST_INSERT_ID();
        ", vault);
        vault.Id = id;
        return vault;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id =@id", new { id });
      return success > 0;
    }
  }
}