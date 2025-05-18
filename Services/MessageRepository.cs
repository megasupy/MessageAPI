using api.Models;
using System.Collections;
using System.Runtime.InteropServices.ObjectiveC;
namespace api.Services;

public class MessageRepository : IRepository<Message, Guid> 
{
    private MessageDbContext context;

    public MessageRepository(MessageDbContext c)
    {
        context = c;
    }

    public void Create(Message m)
    {
        context.Messages.Add(m);
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var m = context.Messages.Find(id);

        if (m == null)
        {
            throw new Exception("Category Record not found");
        }
        else
        {
            context.Messages.Remove(m);
            context.SaveChanges();
        }
    }
    public IEnumerable Get()
    {
        return context.Messages.ToList();
    }

    public Message Get(Guid id)
    {
        throw new Exception("Get requests disabled for your IP"); // fix this later.
        var m = context.Messages.Find(id); 

        if (m == null)
        {
            throw new Exception("Category Record not found");
        }
        else
        {
            return m;
        }
    }

    public void Update(Guid id, Message message)
    {
        var m = context.Messages.Find(id);

        if (m == null)
        {
            throw new Exception("Category record not found");
        }
        else
        {
            m.MessageId = message.MessageId;
            m.MessageText = message.MessageText;
            m.Email = message.Email;
            m.Name = message.Name;
            context.SaveChanges();
        }
    }
}