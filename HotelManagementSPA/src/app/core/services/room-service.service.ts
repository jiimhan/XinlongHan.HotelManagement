import { Injectable } from '@angular/core';
import { ApiServiceService } from './api-service.service';
import { Observable } from 'rxjs';
import { room } from 'src/app/shared/room';
import { basicres } from 'src/app/shared/models/basicres';
import { roomres } from 'src/app/shared/models/roomres';

@Injectable({
  providedIn: 'root'
})
export class RoomServiceService {

  constructor(private apiService: ApiServiceService) { }

  getAllRoom(): Observable<room[]>
  {
    return this.apiService.getList('Room/ListRooms');
  }

  deleteOne(id: number): Observable<basicres>
  {
    return this.apiService.delete('Room/RemoveRoom',id);
  }

  getOneById(id: number): Observable<roomres>
  {
    return this.apiService.getOne('Room/GetById?id=' + id);
  }

  createOne(resource: room): Observable<roomres>
  {
    return this.apiService.create('Room/AddRoom',resource);
  }

  updateOne(resource: room): Observable<roomres>
  {
    return this.apiService.update('Room/UpdateRoom',resource);
  }
}
