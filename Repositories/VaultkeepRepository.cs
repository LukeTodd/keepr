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

    public IEnumerable<Keep> GetAllByVaultId(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId 
WHERE (vaultId = @vaultId AND vk.userId = @userId) 
", new { vaultId, userId });
    }
    public VaultKeeps GetById(int Id)
    {
      return _db.QueryFirstOrDefault<VaultKeeps>("SELECT * FROM vaultkeeps WHERE id = @Id", new { Id });
    }
    public VaultKeeps CreateVaultKeeps(VaultKeeps vaultKeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (vaultId, keepId, userId)
        VALUES (@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID();
        ", vaultKeep);
        vaultKeep.Id = id;
        return vaultKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
    public bool Delete(int vaultId, int keepId)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @VaultId AND keepId = @KeepId", new { vaultId, keepId });
      return success > 0;
    }
  }
}