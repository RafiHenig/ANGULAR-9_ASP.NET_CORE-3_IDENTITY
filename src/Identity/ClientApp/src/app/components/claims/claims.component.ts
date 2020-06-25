import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-claims',
  templateUrl: './claims.component.html',
  styleUrls: ['./claims.component.scss']
})
export class ClaimsComponent implements OnInit {

  public claims: ClaimsVM[] = [];
  public userName: string = '';

  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string) {
  }

  ngOnInit(): void {
    this.http.get<UserClaims>(this.baseUrl + 'api/account/claims').subscribe(
      ({ claims, userName }) => {
        this.claims = claims;
        this.userName = userName;
      },
      error => console.error(error)
    );
  }

}

interface ClaimsVM {
  type: string;
  value: string;
}

interface UserClaims {
  claims: ClaimsVM[];
  userName: string;
}
