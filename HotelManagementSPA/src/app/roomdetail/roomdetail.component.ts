import { Component, OnInit } from '@angular/core';
import { RoomServiceService } from '../core/services/room-service.service';
import { Router, ActivatedRoute } from '@angular/router';
import { room } from '../shared/room';
import { RoomtypeService } from '../core/services/roomtype.service';
import { roomtypedetail } from '../shared/roomtype';


@Component({
  selector: 'app-roomdetail',
  templateUrl: './roomdetail.component.html',
  styleUrls: ['./roomdetail.component.css']
})
export class RoomdetailComponent implements OnInit {

  room!: room;
  id!: number;
  roomtypes!: roomtypedetail[];

  constructor(private roomService: RoomServiceService, private roomtypeService: RoomtypeService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.id = params.get('id') ? Number(params.get('id')) : 0;
        console.log(this.id);
        if(this.id == 0)
        {
          var obj = { id:0, roomTypeId:0, status:false } as room;
          this.room = obj;
        }
        else
        {
          this.roomService.getOneById(this.id).subscribe(res => {
            this.room = res.room;
            console.log(this.room);
          });
        }
        this.roomtypeService.getAllRoomType().subscribe(types => {
          this.roomtypes = types;
          // console.log(this.roomtypes);
        });
      }
    );
  }

  Update()
  {
    console.log(this.room);
    if(this.id == 0)
    {
      this.roomService.createOne(this.room).subscribe(res => {
        console.log(res.message);
      });
    }
    else
    {
      this.roomService.updateOne(this.room).subscribe(res => {
        console.log(res.message);
      });
    }
    this.router.navigate(['/room']);
  }

}
