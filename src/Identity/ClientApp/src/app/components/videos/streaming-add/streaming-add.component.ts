import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-streaming-add',
  templateUrl: './streaming-add.component.html',
  styleUrls: ['./streaming-add.component.css']
})
export class StreamingAddComponent {
  public categories: StreamingCategoryVM[] = [];
  public newVideo: VideoVM = new VideoVM();

  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    private router: Router
  ) {
    this.http.get<StreamingCategoryVM[]>(this.baseUrl + 'api/streaming/videos/register').subscribe(x => {
      this.categories = x;
      this.newVideo.category = this.categories[0].category;
    }, console.error);
  }

  addVideo() {
    console.log(this.newVideo);

    this.http.post(this.baseUrl + 'api/streaming/videos/add', this.newVideo)
      .subscribe(result => {
        this.router.navigate(['videos', this.newVideo.category]);
      }, console.error);
  }
}


interface StreamingCategoryVM {
  category: string;
  value: number;
  registered: boolean;
}

class VideoVM {
  url: string;
  title: string;
  description: string;
  category: string;
}
