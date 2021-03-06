import { Injectable, Inject } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { HttpClient } from '@angular/common/http';

export interface UserState {
  userName: string;
  isAuthenticated: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ClaimsGuard implements CanActivate {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
  ) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.http
      .get<UserState>(`${this.baseUrl}api/account/authenticated`)
      .pipe(map(x => x.isAuthenticated))
  }

}
