using System;
using System.Collections.Generic;
using following.Models;

namespace following.Repositories
{
  public class ProfilesService
  {
    private readonly ProfilesRepository ps_repo;

    public ProfilesService(ProfilesRepository ps_repo)
    {
      this.ps_repo = ps_repo;
    }

    internal List<Profile> GetAll()
    {
      return ps_repo.GetAll();
    }

    internal Profile GetById(string id)
    {
      Profile found = ps_repo.GetById(id);
      if (found == null)
      {
        throw new Exception("invaild id");
      }
      return found;
    }



    internal List<FollowViewModel> GetFollowing(string id)
    {
      return ps_repo.GetFollowing(id);
    }

    internal List<FollowViewModel> GetFollower(string id)
    {
      return ps_repo.GetFollower(id);
    }
  }
}