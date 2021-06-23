import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtStorageService { //get TOKEN, used it in authentication service, it can be reuse accross application

  constructor() { }

  getToken(): string {
    return JSON.parse(localStorage.getItem('token')|| '{}');
    //store it into localStorage(browser object)
  }
  saveToken(token: string) {
    localStorage.setItem('token', token);
  }
  destroyToken() {
    localStorage.removeItem('token');
  }

}