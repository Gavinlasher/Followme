using System;
using following.Models;
using following.Repositories;

namespace following.Services
{
  public class FollowsService
  {
    private readonly FollowsRepository fs_repo;

    public FollowsService(FollowsRepository fs_repo)
    {
      this.fs_repo = fs_repo;
    }

    internal Follow Create(Follow followData)
    {
      //   Follow exist = fs_repo.Get(followData.Follower, followData.Following);
      //   if (exist == null)
      //   {
      //     return exist;

      return fs_repo.Create(followData);
    }
    internal Follow GetById(int id)
    {
      Follow found = fs_repo.GetById(id);
      if (found == null)
      {
        throw new System.Exception("invaild id");
      }
      return found;
    }

    internal void Delete(int followId, string userId)
    {
      Follow found = GetById(followId);
      if (found.Follower != userId)
      {
        throw new Exception("You do not have permission to do that");
      }
      fs_repo.Delete(followId);
    }
  }
}