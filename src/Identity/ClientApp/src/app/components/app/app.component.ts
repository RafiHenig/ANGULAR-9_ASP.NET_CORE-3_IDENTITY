import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StateService } from '../../core/state.service';
import { tap } from 'rxjs/operators';

export interface UserState {
  userName: string;
  isAuthenticated: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(
    private http: HttpClient,
    private state: StateService,
    @Inject('BASE_URL') public baseUrl: string,
  ) { }

  ngOnInit(): void {
    this.http
      .get<UserState>(`${this.baseUrl}api/account/authenticated`)
      .pipe(
        tap(x => this.state.setAuthentication(x))
      )
      .subscribe()

  }

}
