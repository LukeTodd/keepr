

using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultController : ControllerBase
  {
    private readonly VaultRepository _vr;
    public VaultController(VaultRepository vr)
    {
      _vr = vr;
    }

    //GETVAULTSBYUSERID
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Vault>> GetAllByUserId()
    {
      string userId = HttpContext.User.Identity.Name;
      return Ok(_vr.GetAllByUserId(userId));
    }

    //CREATEVAULT
    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault vault)
    {
      Vault newVault = _vr.CreateVault(vault);
      if (newVault == null) { return BadRequest(); }
      return Ok(newVault);
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vr.Delete(id);
      if (!successful) { return BadRequest(); }
      return Ok();
    }
  }
}