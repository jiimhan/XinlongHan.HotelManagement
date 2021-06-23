import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  private headers: HttpHeaders | undefined;
  constructor(private http: HttpClient) { }

  //get array of json objects
  getList(path: string): Observable<any[]> {
    //var apiurl = environment.apiurl;

    return this.http.get(`${environment.apiurl}${path}`).pipe(
      map(resp => resp as any[])
    )
  }

  //get single object
  getOne(path: string/*, id?: numberid? which means this parameter is optional*/): Observable<any> {
    console.log('from apiService' + `${environment.apiurl}${path}`);
    return this.http.get(`${environment.apiurl}${path}`).pipe(
      map(resp => resp as any)
    )
  }

  //post something
  create(path: string, resource: any, options?: any): Observable<any> {
    return this.http
      .post(`${environment.apiurl}${path}`, resource, { headers: this.headers })
      .pipe(map(response => response as any));
  }

  //PUT
  update(path: string,resource: any): Observable<any> {
    return this.http
    .put(`${environment.apiurl}${path}`,resource, { headers: this.headers })
    .pipe(map (response => response as any));
  }

  //Delete
  delete(path: string,id : number): Observable<any> {
    return this.http
    .delete(`${environment.apiurl}${path}`+ '/?id=' + id)
    .pipe(map(resp => resp as any));
  }
}
