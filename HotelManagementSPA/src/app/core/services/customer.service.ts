import { Injectable } from '@angular/core';
import { ApiServiceService } from './api-service.service';
import { Observable } from 'rxjs';
import { cust } from 'src/app/shared/models/cust';
import { customer } from 'src/app/shared/customer';
import { basicres } from 'src/app/shared/models/httpinfo';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private apiService: ApiServiceService) { }

  getAllCusts(): Observable<cust[]>
  {
    return this.apiService.getList('Customer/GetAllCustomers');
  }

  getOneCustById(id: number): Observable<customer>
  {
    return this.apiService.getOne('Customer/GetById?id=' + id);
  }

  deleteOne(id: number): Observable<basicres>
  {
    return this.apiService.delete('Customer/DeleteCustomer',id);
  }

  createOne(resouce: any): Observable<customer>
  {
    return this.apiService.create('Customer/AddCustomer',resouce);
  }

  updateOne(resource: any): Observable<customer>
  {
    console.log('upateonecalled');
    return this.apiService.update('Customer/UpdateCustomer',resource);
  }
}
