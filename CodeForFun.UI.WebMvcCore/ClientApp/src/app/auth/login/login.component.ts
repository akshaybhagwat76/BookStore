import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from "angularx-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { AccountService } from 'src/app/services/account.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  socialLogin: any = {};
  visibility:any;
  @Output() user = new EventEmitter<any>();

  constructor(private authService: AuthService,private accountService:AccountService,private router:Router) { }

  ngOnInit() {
    this.visibility = true;
    this.authService.authState.subscribe(x => {
      if (x != null) {
        this.socialLogin.name = x.name || null;
        this.socialLogin.email = x.email || null;
        this.user.emit(this.socialLogin);
      }
    })
  }

  signInWithFB() {
    this.authService.signIn(FacebookLoginProvider.PROVIDER_ID);
  }
  signInWithGoogle() {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then(x => {
      this.socialLogin.name = x.name;
      this.socialLogin.email = x.email;

      this.user.emit(this.socialLogin)

    });
  }
  logOut(){
    this.authService.signOut();
  }

  login(){
    this.accountService.login(this.model).subscribe(x => {
      localStorage.setItem('token', x.token);
      this.user.emit(this.model);
      this.visibility = false;
    })
  }

}
