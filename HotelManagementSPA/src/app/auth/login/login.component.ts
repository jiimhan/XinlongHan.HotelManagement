import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authetication.service';
import { UserLogin } from 'src/app/shared/models/userlogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLogin: UserLogin = {
    email: '', password: ''
  };
  invalidLogin!: boolean;

  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    // console.log('inside login method, checking UserLogin object');
    // console.log('form submitted here');
    // console.log(this.userLogin);
    this.authService.login(this.userLogin).subscribe(
      (response) => {
        if (response) {
          
          //  redirect to home page
          this.router.navigate(['/']);
          this.invalidLogin = false;
        }
      }, 
      (err: any) => { this.invalidLogin = true });

  }

}
