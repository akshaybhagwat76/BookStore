import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LocalStorage } from '@ngx-pwa/local-storage';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  jwt = new JwtHelperService();
  auth: Subject<any> = new Subject();
  token: any;
  userName: string;

  login(model: any) {
    const sub = new Subject<any>();
      
    this.http.post('api/account/login', model).subscribe((x: any) => {

      if (x) {
        this.localStoraService.setItem('userToken', { access_token: x.token,userName: model.email }).subscribe((z: any) => {
          sub.next(x);
          this.token = x.token
          this.userName = model.email;
          this.auth.next(x);
          sub.complete();
        })
      }
    }, error => {
      this.logOut();
      sub.error(error);
      this.auth.error(error);
      return error;
    })
    return sub;
  }

  getToken() {
    this.fillAuth();
    return this.token;
  }

  register(model: any) {
    const sub = new Subject<any>();

    this.http.post('/api/account/register', model).subscribe((x: any) => {
      this.localStoraService.setItem('userToken', {access_token: x.token,userName: model.email }).subscribe((z: any) => {
        this.userName = model.userName;
        this.token = x.token
        sub.next(x);
        sub.complete();
      })
    })
    return sub;
  }

  logOut() {
    const sub = new Subject<any>();
    this.localStoraService.removeItem('userToken').subscribe(x => {
      sub.next(x)
      sub.complete();
    })
    return sub;
  }

  isLogged() {
    const sub = new Subject<any>();
    this.localStoraService.getItem('userToken').subscribe((x: any) => {
      if (x) {
        if (!this.jwt.isTokenExpired(x.access_token)) {
          sub.next(x);
          sub.complete();
        }
      }
    })
    return sub;
  }

  fillAuth() {
    this.localStoraService.getItem('userToken').subscribe((x: any) => {
      if (x) {
        this.auth.next(x)
        this.token = x.access_token
      }
    })
  }

  decodeToken() {
    const sub = new Subject<any>();

    this.localStoraService.getItem('userToken').subscribe((x: any) => {
      this.token = x.access_token;
      sub.next(this.token);
      sub.complete();
    })
    return sub;
  }

  constructor(private http: HttpClient, private localStoraService: LocalStorage) { }
}
