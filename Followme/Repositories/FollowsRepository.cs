using System.Data;
using Dapper;
using following.Models;

namespace following.Repositories
{
  public class FollowsRepository
  {
    private readonly IDbConnection _db;

    public FollowsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Follow Create(Follow followData)
    {
      string sql = @"
      INSERT INTO follows
      (follower, following)
      VALUES
      (@Follower, @Following);
        SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, followData);
      followData.Id = id;
      return followData;
    }

    internal Follow Get(string followerid, string followingid)
    {
      string sql = @"
      SELECT * FROM follows
      WHERE follower = @followerid AND following = @followingid
      ";

      return _db.QueryFirstOrDefault<Follow>(sql, new { followerid, followingid });
    }

    internal Follow GetById(int id)
    {
      string sql = @"SELECT * FROM follows WHERE id = @id";
      return _db.QueryFirstOrDefault<Follow>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM follows WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}
