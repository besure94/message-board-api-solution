namespace MessageBoardApi.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Group { get; set; }
    public string UserMessage { get; set; }
    public string Author { get; set; }
    public DateTime Date { get; set; }
  }
}