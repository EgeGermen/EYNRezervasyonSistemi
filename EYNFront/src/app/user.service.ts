import { Injectable } from '@angular/core';
import { User } from './user.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  private user: User = {
    name: 'Mevcut Kullanıcı',
    email: 'kullanici@ornek.com',
    password: '123456'
  };

  getUser(): User {
    return { ...this.user };
  }

  updateUser(user: User) {
    this.user = { ...user };
  }
} 