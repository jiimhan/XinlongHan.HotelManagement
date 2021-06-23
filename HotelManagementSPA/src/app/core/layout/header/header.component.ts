import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authetication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isAuth! : boolean;

  constructor(private authService: AuthenticationService) { }

  ngOnInit(): void {
    //console.log('in the init method:' + this.isAuth);
    this.authService.isAuthenticated.subscribe(auth => {
      this.isAuth = auth;
      // console.log('Auth Status:' + this.isAuth);
    });
  }

}
