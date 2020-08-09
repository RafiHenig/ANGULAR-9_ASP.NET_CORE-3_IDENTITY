import { Component, OnInit } from '@angular/core';
import { IContact } from '../../core/domain';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { StateService } from '../../core/state.service';
import { OpenIdConnectService } from '../../core/openid-connect.service';

@Component({
  selector: 'app-social-api',
  templateUrl: './social-api.component.html',
  styleUrls: ['./social-api.component.css']
})
export class SocialApiComponent {

  public socialLoggedIn: any;
  public contacts: IContact[] = [];
  public socialApiAccessDenied: boolean = false;

  constructor(
    public http: HttpClient,
    public openConnectIdService: OpenIdConnectService,
    public router: Router,
    public stateService: StateService
  ) {

    openConnectIdService.getUser().then((user: any) => {
      if (user)
      {
        console.log("User logged in", user.profile);
        console.log(user);
        this.socialLoggedIn = true;
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${user.access_token}` });
        const socialApiContactsURI = "http://localhost:5005/api/contacts";

        this.http.get<IContact[]>(socialApiContactsURI, { headers: headers }).subscribe(result => {
          this.contacts = result;

        }, error => {
          if (error.status === 401)
          {
            this.socialApiAccessDenied = true;
          }
        });
      }

    });
  }

  login() {
    this.openConnectIdService.login();
  }

  logout() {
    this.openConnectIdService.logout();
  }
}
