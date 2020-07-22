export enum StreamingCategory {
  ACTION_AND_ADVENTURE = 1,
  ACTION_COMEDIES = 2,
  ACTION_THRILLERS = 3,
  SCI_FI = 4,
  ANIMATION = 5,
  MUSIC_VIDEOS = 6,
  BOXING_MOVIES = 7,
  FAMILY_MOVIES = 8
}

export class VideoVM {
  public url: string;
  public title: string;
  public description: string;
  public category: StreamingCategory
}


