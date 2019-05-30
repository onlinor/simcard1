import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { User, Login } from '../models';

@Injectable()
export class AuthService {
  constructor(private apiService: ApiService) {}

  public get currentUserValue(): User {
    return JSON.parse(localStorage.getItem('currentUser'));
  }

  public get isAuthenticated(): boolean {
    return JSON.parse(localStorage.getItem('currentUser')) !== null;
  }

  login(loginInfo: Login): Observable<any> {
    return this.apiService.post('/auth/login', loginInfo);
  }

  logout() {
    localStorage.removeItem('currentUser');
  }
}
