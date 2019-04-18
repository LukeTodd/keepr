
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api[controller]")]
  [ApiController]
  public class VaultKeepController : ControllerBase
  {
    private readonly VaultKeepRepository _vr;
    public VaultKeepController(VaultKeepRepository vr)
    {
      _vr = vr;
    }

    //GET ALL VAULT KEEPS BY VAULT ID
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<VaultKeeps>> GetAllByVaultId(int id)
    {
      return Ok(_vr.GetAllByVaultId(id));
    }
  }
}