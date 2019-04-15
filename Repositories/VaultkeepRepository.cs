using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<VaultKeeps> GetAllByUserId()
    {
      return _db.Query<VaultKeeps>("SELECT * FROM vaultkeeps");
    }
    public VaultKeeps GetById(int Id)
    {
      return _db.QueryFirstOrDefault<VaultKeeps>("SELECT * FROM vaultkeeps WHERE id = @Id", new { Id });
    }
    public VaultKeeps CreateVaultKeeps(VaultKeeps vaultkeeps)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (vaultid, keepid, userid)
        VAULES(@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID();
        ", vaultkeeps);
        vaultkeeps.Id = id;
        return vaultkeeps;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
    public bool Delete(int Id)
    {
      int success = _db.Execute("DELETE FROM games WHERE id = @Id", new { Id });
      return success > 0;
    }
  }
}