//-
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace WebApplication3.Models;

public class MessageRepository : Repository<Message>
{
    public MessageRepository(ApplicationDbContext db)
        : base(db)
    {
    }

    public List<Message> GetMessages(User sender, User recipient)
    {
        base.Set.Include(x => x.Recipient);
        base.Set.Include(x => x.Sender);

        var from = base.Set.AsEnumerable()
            .Where(x => x.SenderId == sender.Id && x.RecipientId == recipient.Id).ToList();

        var to = base.Set.AsEnumerable()
            .Where(x => x.SenderId == recipient.Id && x.RecipientId == sender.Id).ToList();

        var itog = new List<Message>();
        itog.AddRange(from);
        itog.AddRange(to);
        itog.OrderBy(x => x.Id);
        
        return itog;
    }
}
