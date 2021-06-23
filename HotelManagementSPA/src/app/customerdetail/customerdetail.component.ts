import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../core/services/customer.service';
import { Router, ActivatedRoute } from '@angular/router';
import { customer } from '../shared/customer';
import { RoomServiceService } from '../core/services/room-service.service';
import { room } from '../shared/room';

@Component({
  selector: 'app-customerdetail',
  templateUrl: './customerdetail.component.html',
  styleUrls: ['./customerdetail.component.css']
})
export class CustomerdetailComponent implements OnInit {
  id!: number;
  customer!: customer;
  invalid: boolean = false;
  message: string = '';
  room!: room[];

  constructor(private roomSerive: RoomServiceService,private customerService: CustomerService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.id = params.get('id') ? Number(params.get('id')) : 0;
        console.log(this.id);
        if(this.id == 0)
        {
          var obj = { id: 0, roomId: 0, cName: '', address: '', phone: '', email: '', checkIn: new Date(),  totalPersons: 0, bookingDays: 0, advance: 0, message: '', statusCode: 0} as customer;
          this.customer = obj;
        }
        else
        {
          this.customerService.getOneCustById(this.id).subscribe(res => {
            this.customer = res;
            console.table(this.customer);
          });
        }
        this.roomSerive.getAllRoom().subscribe(res => {
          this.room = res;
        });
      }
    );
  }

  Update()
  {
    console.log(this.customer);
    if(this.id == 0)
    {
      this.customerService.createOne(this.customer).subscribe(res => {
        if(res.message != "Success")
        {
          this.invalid = true;
          this.message = res.message;
        }
        else
        this.router.navigate(['/customer']);
      });
    }
    else
    {
      this.customerService.updateOne(this.customer).subscribe(res => {
        if(res.message != "Success")
        {
          this.invalid = true;
          this.message = res.message;
        }
        else
        this.router.navigate(['/customer']);
      });
    }
  }

}
