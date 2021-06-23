import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from 'src/app/shared/models/user';
import { UserLogin } from 'src/app/shared/models/userlogin';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { JwtStorageService } from './jwt-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private user! : User;

  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable();

  public isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private http: HttpClient, private jwtStorageService: JwtStorageService) { }


  login(userLogin: UserLogin): Observable<boolean> {
    // take the userLogin object from login component and send it to API
    // if api validates un/pw return token
    // store that token in localstorage return true
    // return false;
    // https://localhost:44368/api/Account/login

    return this.http.post(`${environment.apiurl}${'user/login'}`, userLogin)
      .pipe(map((response: any) => {
        console.log(response);
        localStorage.setItem('jwtToken', response.token);
        this.populateUserData();
        return true;
      }
      ));

  }

  populateUserData(){
    const helper = new JwtHelperService();
    var myJwtToken = localStorage.getItem('jwtToken');
    if(myJwtToken){
      const decodedToken = helper.decodeToken(myJwtToken);
      this.user = decodedToken;
      this.currentUserSubject.next(this.user);
      this.isAuthenticatedSubject.next(true);
    }
  }

  logout() {

    // remove the token from local storage
    localStorage.removeItem('jwtToken');
    //clear aout the 
    this.currentUserSubject.next({} as User);
    this.isAuthenticatedSubject.next(false);

  }

  populateUserInfo(){
    if (this.jwtStorageService.getToken()) {
      const token = this.jwtStorageService.getToken();
      const decodedToken = this.decodedToken();
      this.currentUserSubject.next(decodedToken); //push User into subject
      this.isAuthenticatedSubject.next(true); //.next() --> send value to observable
    }
  }
  private decodedToken():User {
    const token = this.jwtStorageService.getToken();
    if (!token || new JwtHelperService().isTokenExpired(token)) {
      this.logout(); //destroy token
    }
    const decodedToken = new JwtHelperService().decodeToken(token);
    this.user = decodedToken; //get decoded information in payload
    return this.user;
  }
}