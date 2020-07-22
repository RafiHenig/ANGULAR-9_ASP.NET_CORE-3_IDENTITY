using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Identity.Models;

namespace Identity.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    public readonly UserManager<IdentityUser> _userManager;

    public UserController(UserManager<IdentityUser> userManager)
    {
      _userManager = userManager;
    }

    // GET api/user
    [HttpGet("")]
    public ActionResult<IEnumerable<string>> Getstrings()
    {
      return Ok(_userManager.Users);
    }

    // GET api/user/5
    [HttpGet("{id}")]
    public ActionResult<string> GetstringById(int id)
    {
      return null;
    }

    // POST api/user
    [HttpPost("")]
    public void Poststring(string value)
    {
    }

    // PUT api/user/5
    [HttpPut("{id}")]
    public void Putstring(int id, string value)
    {
    }

    // DELETE api/user/5
    [HttpDelete("{id}")]
    public void DeletestringById(int id)
    {
    }
  }
}