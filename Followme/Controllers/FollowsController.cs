using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using following.Models;
using following.Services;
using Followme.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace following.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class FollowsController : ControllerBase
  {
    private readonly FollowsService _fs;

    public FollowsController(FollowsService fs)
    {
      _fs = fs;
    }
    [HttpPost]
    public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        followData.Follower = userInfo.Id;
        Follow follow = _fs.Create(followData);
        return Ok(follow);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        _fs.Delete(id, user.Id);
        return Ok("Delorted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}