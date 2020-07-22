using System;
using System.Collections.Generic;
using identity.Vms;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Infrastructure
{

  public static class VideoRepository
  {
    public static List<VideoVM> Videos;

    static VideoRepository()
    {
      Videos = new List<VideoVM>();

      // ACTION_AND_ADVENTURE Videos
      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "Tomb Raider",
        Description = "Trailer #1",
        Category = StreamingCategory.ACTION_AND_ADVENTURE
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "SICARIO: DAY OF THE SOLDADO",
        Description = "Official Trailer (HD)",
        Category = StreamingCategory.ACTION_AND_ADVENTURE
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "Mile 22",
        Description = "Trailer #1",
        Category = StreamingCategory.ACTION_AND_ADVENTURE
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "Mission: Impossible - Fallout (2018)",
        Description = "Official Trailer",
        Category = StreamingCategory.ACTION_AND_ADVENTURE
      });

      // ACTION_COMEDIES Videos
      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "GAME NIGHT",
        Description = "Trailer #1",
        Category = StreamingCategory.ACTION_COMEDIES
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "The Spy Who Dumped Me",
        Description = "Trailer #1",
        Category = StreamingCategory.ACTION_COMEDIES
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "Johnny English Strikes Again",
        Description = "Official Trailer (HD)",
        Category = StreamingCategory.ACTION_COMEDIES
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "OCEAN'S 8",
        Description = "Official 1st Trailer",
        Category = StreamingCategory.ACTION_COMEDIES
      });

      // ACTION_THRILLERS Videos
      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "Insidious: The Last Key",
        Description = "Official Trailer",
        Category = StreamingCategory.ACTION_THRILLERS
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "VENOM",
        Description = "Official Trailer (HD)",
        Category = StreamingCategory.ACTION_THRILLERS
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "MUTE",
        Description = "Official Trailer (HD)",
        Category = StreamingCategory.ACTION_THRILLERS
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "The Commuter",
        Description = "Official Teaser Trailer ",
        Category = StreamingCategory.ACTION_THRILLERS
      });

      // SCI_FI Videos
      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "Deadpool 2",
        Description = "Official Trailer",
        Category = StreamingCategory.SCI_FI
      });

      // Music Videos
      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "3 Doors Down - Father's Son",
        Description = "Live from Houston",
        Category = StreamingCategory.MUSIC_VIDEOS
      });

      Videos.Add(new VideoVM
      {
        Url = "https://www.youtube.com/embed/PPkUHtrDbko",
        Title = "3 Doors Down - Kryptonite",
        Description = "Live from Houston",
        Category = StreamingCategory.MUSIC_VIDEOS
      });
    }
  }
}