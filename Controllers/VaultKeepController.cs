
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepController : ControllerBase
  {
    private readonly VaultKeepRepository _vkr;
    public VaultKeepController(VaultKeepRepository vkr)
    {
      _vkr = vkr;
    }

    //GET ALL VAULT KEEPS BY VAULT ID
    [Authorize]
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<VaultKeeps>> GetAllByVaultId(int vaultId)
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _vkr.GetAllByVaultId(vaultId, userId);
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //CREATE VAULTKEEP
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeeps> Create([FromBody] VaultKeeps vaultKeep)
    {
      vaultKeep.UserId = HttpContext.User.Identity.Name;
      VaultKeeps newVaultKeep = _vkr.CreateVaultKeeps(vaultKeep);

      if (newVaultKeep == null)
      {
        return BadRequest();
      }
      return Ok(newVaultKeep);

    }

    //Delete VaultKeep
    [HttpDelete("{vaultId}/keep/{keepId}")]
    public ActionResult<string> Delete(int vaultId, int keepId)
    {
      bool successful = _vkr.Delete(vaultId, keepId);
      if (!successful)
      {
        return BadRequest();
      }
      return Ok();
    }
  }
}