using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _kr;
    public KeepsController(KeepRepository kr)
    {
      _kr = kr;
    }

    //GET ALL
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    // GET ALL BY USER ID
    [HttpGet("{userid}")]
    public ActionResult<IEnumerable<Keep>> GetByUserId(string userId)
    {
      return Ok(_kr.GetByUserId(userId));
    }


    //GET KEEP BY ID
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> GetById(int id)
    {
      return Ok(_kr.GetById(id));
    }

    //CREATE KEEP
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep keepr)
    {
      Keep newKeepr = _kr.CreateKeep(keepr);
      if (newKeepr == null) { return BadRequest(); }
      return Ok(newKeepr);
    }

    //DELETE KEEP
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _kr.Delete(id);
      if (!successful) { return BadRequest(); }
      return Ok();
    }
  }
}