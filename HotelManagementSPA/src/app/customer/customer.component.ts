import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../core/services/customer.service';
import { cust } from '../shared/models/cust';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  custs: cust[] | undefined;

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.customerService.getAllCusts().subscribe(res => {
      this.custs = res;
      console.table(this.custs);
    });
  }
  
  delete(id: number)
  {
    this.customerService.deleteOne(id).subscribe(res => {
      console.log(res.message);
      this.ngOnInit();
    });
  }
}
