import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserState } from '../components/app/app.component';

@Injectable({
  providedIn: 'root'
})
export class StateService {

  private readonly userStateSource = new BehaviorSubject<UserState>({ userName: '', isAuthenticated: false, roles: [] });
  public userState$ = this.userStateSource.asObservable();

  constructor() { }

  /**
   * setAuthentication
   */
  public setAuthentication(state: UserState) {
    this.userStateSource.next(state)
  }

  public isAuthenticated(): Observable<boolean> {
    return this.userStateSource.pipe(map(x => x.isAuthenticated))
  }
}

