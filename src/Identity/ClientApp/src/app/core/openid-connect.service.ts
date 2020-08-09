import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject, Observable, combineLatest } from 'rxjs';
import { map, filter } from 'rxjs/operators';
import { OAuthService, OAuthErrorEvent } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { UserManager } from 'oidc-client'

@Injectable({
  providedIn: 'root'
})
export class OpenIdConnectService {
  config = {
    authority: "https://localhost:5003",
    client_id: "AspNetCoreIdentity",
    redirect_uri: "https://localhost:5001",
    response_type: "code",
    scope: "openid profile SocialAPI",
    post_logout_redirect_uri: "http://localhost:5001",
  };
  userManager: any;

  constructor() {
    this.userManager = new UserManager(this.config);
  }

  public getUser() {
    return this.userManager.getUser();
  }

  public login() {
    return this.userManager.signinRedirect();;
  }

  public signinRedirectCallback() {
    return new UserManager({ response_mode: "query" }).signinRedirectCallback();
  }

  public logout() {
    this.userManager.signoutRedirect();
  }
}
