import { Component } from '@angular/core';
import { AuthenticationService } from './core/services/authetication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HotelManagementSPA';
  constructor(private authService: AuthenticationService) {
  }
  ngOnInit() {
    
  }
}
