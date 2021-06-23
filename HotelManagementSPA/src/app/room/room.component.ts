import { Component, OnInit } from '@angular/core';
import { RoomServiceService } from '../core/services/room-service.service';
import { room } from '../shared/room';


@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {

  rooms: room[] | undefined;

  constructor(private roomService: RoomServiceService) { }

  ngOnInit(): void {
    this.roomService.getAllRoom().subscribe(res => {
      this.rooms = res;
      console.log(this.rooms);
    });
  }

  delete(id: number)
  {
    console.log(id);
    this.roomService.deleteOne(id).subscribe(res => {
      console.log(res.message);
      this.ngOnInit();
    });
  }

}
