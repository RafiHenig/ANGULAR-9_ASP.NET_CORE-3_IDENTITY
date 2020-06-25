import { Component, OnInit, Inject } from '@angular/core';
import { StateService } from '../../core/state.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

export interface UserState {
  userName: string;
  isAuthenticated: boolean;
}


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  public userName$: Observable<string>;
  public isAuthenticated$: Observable<boolean>;

  constructor(
    private http: HttpClient,
    private state: StateService,
    private router: Router,
    @Inject('BASE_URL') public baseUrl: string,
  ) { }

  ngOnInit(): void {
    this.userName$ = this.state.userState$.pipe(map(x => x.userName));
    this.isAuthenticated$ = this.state.isAuthenticated()
  }

  public signOut() {
    this.http.post<void>(this.baseUrl + "api/Account/SignOut", null).subscribe(
      () => {
        this.router.navigate(['/login']);
        this.state.setAuthentication({ isAuthenticated: false, userName: "" })
      },
      console.error
    )
  }

}
