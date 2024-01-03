using Microsoft.EntityFrameworkCore;

namespace MessageBoardApi.Models
{
  public class MessageBoardApiContext : DbContext
  {
    public DbSet<Message> Messages { get; set; }
    public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Message>()
        .HasData(
          new Message { MessageId = 1, Group = "Music Makers", UserMessage = "Best drum kit for a beginner?", Author = "newbieDrummer99", Date = DateTime.Today },
          new Message { MessageId = 2, Group = "PC Gamers", UserMessage = "Favorite loadout for Overwatch?", Author = "gamerchick", Date = DateTime.Today.AddDays(-45) },
          new Message { MessageId = 3, Group = "Cycling Enthusiasts", UserMessage = "Looking for rain-resistant tires for my bike", Author = "nightryder82", Date = DateTime.Today.AddDays(-1467) },
          new Message { MessageId = 4, Group = "Hiking fanatics", UserMessage = "Best hiking trails in Cascade mountain range?", Author = "muddyB00tz", Date = DateTime.Today.AddDays(-12987) },
          new Message { MessageId = 5, Group = "Stamp collectors", UserMessage = "Can someone tell me the year of this stamp?", Author = "StampNerd", Date = DateTime.Today.AddDays(-287) }
        );
    }
  }
}