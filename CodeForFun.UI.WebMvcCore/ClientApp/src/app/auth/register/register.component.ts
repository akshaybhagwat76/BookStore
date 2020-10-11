import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from "angularx-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { AccountService } from 'src/app/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  socialLogin: any = {};
  visibility: boolean = true;
  @Output() user = new EventEmitter<any>();

  constructor(private authService: AuthService, private accountService: AccountService, private router: Router) { }

  ngOnInit() {
    this.authService.authState.subscribe(x => {
      debugger
      if (x != null) {
        this.socialLogin.name = x.name || null;
        this.socialLogin.email = x.email || null;
        this.visibility = false;

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
    this.authService.signOut().then(x=>{
      this.accountService.logOut().subscribe(x=>{
        
      })
    });
  }

  register(){
    this.accountService.register(this.model).subscribe(x => {
      this.user.emit(this.model);
      this.visibility= false;

      this.router.navigate['/category'];
    })
  }
}
