import { Injectable } from '@angular/core';
import { ApiServiceService } from './api-service.service';
import { Observable } from 'rxjs';
import { serv } from 'src/app/shared/roomservice';
import { basicres } from 'src/app/shared/models/basicres';
import { servres } from 'src/app/shared/models/services';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private apiService: ApiServiceService) { }

  getAllServs(): Observable<serv[]>
  {
    return this.apiService.getList('Service/GetAllServices');
  }

  deleteOne(id: number): Observable<basicres>
  {
    return this.apiService.delete('Service/DeleteService',id);
  }

  getOneById(id: number): Observable<servres>
  {
    return this.apiService.getOne('Service/GetById?id=' + id);
  }

  updateOne(resource: serv): Observable<servres>
  {
    return this.apiService.update('Service/UpdateService',resource);
  }

  createOne(resource: serv): Observable<servres>
  {
    return this.apiService.create('Service/AddService',resource);
  }
}
