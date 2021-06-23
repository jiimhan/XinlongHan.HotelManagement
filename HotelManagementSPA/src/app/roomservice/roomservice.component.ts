import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../core/services/service.service';
import { RoomServiceService } from '../core/services/room-service.service';
import { Router, ActivatedRoute } from '@angular/router';
import { serv } from '../shared/roomservice';

@Component({
  selector: 'app-roomservice',
  templateUrl: './roomservice.component.html',
  styleUrls: ['./roomservice.component.css']
})
export class RoomserviceComponent implements OnInit {

  id!: number;
  servi!: serv;
  invalid: boolean = false;
  message: string = '';

  constructor(private service: ServiceService, private roomService: RoomServiceService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.id = params.get('id') ? Number(params.get('id')) : 0;
        console.log(this.id);
        if (this.id == 0) {
          var obj = { id: 0, roomId: 0, amount: 0, sdesc: '', serviceDate: new Date() } as serv;
          this.servi = obj;
        }
        else {
          this.service.getOneById(this.id).subscribe(res => {
            console.log(res);
            this.servi = res.service;
          });
        }
      }
    );
  }

  Update() {
    console.log(this.servi);
    if (this.id == 0) {
      this.service.createOne(this.servi).subscribe(res => {
        if (res.message != "Success") {
          this.invalid = true;
          this.message = res.message;
        }
        else
          this.router.navigate(['/service']);
      });
    }
    else {
      this.service.updateOne(this.servi).subscribe(res => {
        if (res.message != "Success") {
          this.invalid = true;
          this.message = res.message;
        }
        else
          this.router.navigate(['/service']);
      });
    }
  }

}
