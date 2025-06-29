//-
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace WebApplication3.Models;

public class FriendsRepository : Repository<Friend>
{
    public FriendsRepository(ApplicationDbContext db)
        : base(db)
    {
    }

    public void AddFriend(User target, User Friend)
    {
        var friends = base.Set.AsEnumerable()
            .FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

        if (friends == null)
        {
            var item = new Friend()
            {
                UserId = target.Id,
                User = target,
                CurrentFriend = Friend,
                CurrentFriendId = Friend.Id,
            };

            Create(item);
        }
    }

    public List<User> GetFriendsByUser(User target)
    {
        /*
        var friends = base.Set
            .Include(x => x.CurrentFriend).Include(x => x.User).AsEnumerable()
            .Where(x => x.User.Id == target.Id).Select(x => x.CurrentFriend).OfType<User>();
        */
        var friends = base.Set
            .Include(x => x.CurrentFriend).AsEnumerable()
            .Where(x => x.User.Id == target.Id).Select(x => x.CurrentFriend).OfType<User>();

        return friends.ToList();
    }

    public void DeleteFriend(User target, User Friend)
    {
        var friends = base.Set.AsEnumerable()
            .FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

        if (friends != null)
        {
            Delete(friends);
        }
    }
}
