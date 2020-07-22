import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StateService } from '../../core/state.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  // public movies: string[];

  // constructor(
  //   private http: HttpClient,
  //   private state: StateService,
  //   @Inject('BASE_URL') public baseUrl: string,
  // ) { }

  ngOnInit(): void {
    //   this.http
    //     .get<string[]>(`${this.baseUrl}api/movie`)
    //     .pipe(
    //       tap(console.log))
    //     .subscribe(x => this.movies = x)

  }
}
