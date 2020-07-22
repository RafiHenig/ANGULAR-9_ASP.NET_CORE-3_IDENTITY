
namespace identity.Vms
{
  public enum StreamingCategory
  {
    ACTION_AND_ADVENTURE = 1,
    ACTION_COMEDIES = 2,
    ACTION_THRILLERS = 3,
    SCI_FI = 4,
    ANIMATION = 5,
    MUSIC_VIDEOS = 6,
    BOXING_MOVIES = 7,
    FAMILY_MOVIES = 8
  }

  public class VideoVM
  {
    public string Url { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public StreamingCategory Category { get; set; }
  }
}