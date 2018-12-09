import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {User} from '../models/user';
import {BaseService} from './base.service';
import {ServerEndpoints} from './serverendpoints';



@Injectable({ providedIn: 'root' })
export class UserService extends BaseService {
  constructor(http: HttpClient) {
    super(http);
  }

  getById(id: number) {
    return this.extendedHttp.get(ServerEndpoints.GETBYID, id);
  }

  register(user: User) {
    return this.extendedHttp.post(ServerEndpoints.REGISTER, user);
  }

}
