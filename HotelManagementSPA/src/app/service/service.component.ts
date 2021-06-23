import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../core/services/service.service';
import { serv } from '../shared/serv';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent implements OnInit {

  servs: serv[] | undefined;

  constructor(private service: ServiceService) { }

  ngOnInit(): void {
    this.service.getAllServs().subscribe(res => {
      this.servs = res
      console.table(this.servs);
    });
  }

  delete(id: number)
  {
    console.log(id);
    this.service.deleteOne(id).subscribe(res => {
      console.log(res.message);
    });
    this.ngOnInit();
  }

}
