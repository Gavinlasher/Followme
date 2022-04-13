
using System;
using System.Collections.Generic;
using following.Models;
using following.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace following.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;

    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }
    [HttpGet]
    public ActionResult<List<Profile>> GetAll()
    {
      try
      {
        List<Profile> profiles = _ps.GetAll();
        return Ok(profiles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<List<Profile>> GetById(string id)
    {
      try
      {
        Profile profile = _ps.GetById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/following")]
    public ActionResult<List<FollowViewModel>> GetProfileFollowing(string id)
    {
      try
      {
        List<FollowViewModel> following = _ps.GetFollowing(id);
        return Ok(following);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/followers")]
    public ActionResult<List<FollowViewModel>> GetProfileFollowers(string id)
    {
      try
      {
        List<FollowViewModel> follower = _ps.GetFollower(id);
        return Ok(follower);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}