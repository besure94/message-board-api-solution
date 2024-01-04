using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;

namespace MessageBoardApi.Controllers.v2
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("2.0")]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public MessagesController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string group, string minimumDate, string maximumDate, int pageNumber)
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();

      if (group != null)
      {
        query = query.Where(entry => entry.Group == group);
      }

      if (minimumDate != null && maximumDate != null)
      {
        DateTime minDate = DateTime.Parse(minimumDate);
        DateTime maxDate = DateTime.Parse(maximumDate);
        query = query.Where(entry => entry.Date >= minDate).Where(entry => entry.Date <= maxDate);
      }

      if (pageNumber > 0)
      {
        int pageSize = 5;
        List<Message> paginatedQueryMessages = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return paginatedQueryMessages;
      }

      return await query.ToListAsync();
    }

    [HttpGet("groupList")]
    public async Task<ActionResult<List<string>>> GetAllGroups()
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();

      List<string> fullGroupList = await query.Select(message => message.Group).Distinct().ToListAsync();

      return fullGroupList;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      Message message = await _db.Messages.FindAsync(id);

      if (message == null)
      {
        return NotFound();
      }

      return message;
    }

    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, string author, Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }

      if (author.ToLower() != message.Author.ToLower())
      {
        return BadRequest();
      }

      _db.Messages.Update(message);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    private bool MessageExists(int id)
    {
      return _db.Messages.Any(entry => entry.MessageId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id, string author)
    {
      Message message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      if (author.ToLower() != message.Author.ToLower())
      {
        return BadRequest();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}