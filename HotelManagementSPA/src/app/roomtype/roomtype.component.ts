import { Component, OnInit } from '@angular/core';
import { RoomtypeService } from '../core/services/roomtype.service';
import { roomtypedetail } from '../shared/roomtype';

@Component({
  selector: 'app-roomtype',
  templateUrl: './roomtype.component.html',
  styleUrls: ['./roomtype.component.css']
})
export class RoomtypeComponent implements OnInit {

  types: roomtypedetail[] | undefined;

  constructor(private roomtype: RoomtypeService) { }

  ngOnInit(): void {
    this.roomtype.getAllRoomType().subscribe(t => {
      this.types = t;
      console.log(t);
    });
  }

  delete(id: number)
  {
    console.log(id);
    this.roomtype.deleteRoomType(id).subscribe(res => {
      console.log(res.message);
      this.ngOnInit();
    }); 
  }

}
