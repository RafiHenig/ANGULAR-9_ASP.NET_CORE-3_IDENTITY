import { Component, OnInit, Inject } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { VideoVM } from '../../core/domain';

@Component({
  selector: 'app-videos',
  templateUrl: './streaming.component.html',
  styleUrls: ['./streaming.component.css']
})
export class StreamingComponent  implements OnInit {
  public videos: VideoVM[] = [];
  public category: string = '';
  private sub: any;

  constructor(public http: HttpClient, public sanitizer: DomSanitizer,
      @Inject('BASE_URL') public baseUrl: string, private route: ActivatedRoute, ) {
  }

  ngOnInit() {
      this.sub = this.route.params.subscribe(params => {
          this.category = params['id'] || '';
          var route = this.category.length === 0 ? 'videos' : this.category
          this.http.get<VideoVM[]>(this.baseUrl + `api/streaming/${route}`).subscribe(x => {
              this.videos = x;
          }, error => console.error(error));
      });
  }

  ngOnDestroy() {
      this.sub.unsubscribe();
  }

  sanitizeUrl(url: string) {
      return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}

