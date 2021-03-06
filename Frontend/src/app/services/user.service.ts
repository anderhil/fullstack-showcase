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

  getByUserName(userName: string) {
    return this.extendedHttp.get<User>(ServerEndpoints.USERSAPI, userName);
  }

  getAll() {
    return this.extendedHttp.get<User[]>(ServerEndpoints.USERSAPI);
  }

  register(user: User) {
    return this.extendedHttp.post(ServerEndpoints.REGISTER, user);
  }

  update(user: User) {
    return this.extendedHttp.put(ServerEndpoints.USERSAPI, user, user.username);
  }

  delete(userName: string) {
    return this.extendedHttp.delete(ServerEndpoints.USERSAPI, userName);
  }

}
