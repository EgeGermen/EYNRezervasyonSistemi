import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user.model'; // User modelini import et

@Injectable({ providedIn: 'root' })
export class UserService {
  private apiUrl = 'https://localhost:7076/api/users';

  // 💡 Eksik olan kısım: user property
  private user: User = {
    name: 'Mevcut Kullanıcı',
    email: 'kullanici@ornek.com',
    password: '123456'
  };

  constructor(private http: HttpClient) {}

  registerUser(data: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, data);
  }

  getUser(): User {
    return { ...this.user };
  }

  updateUser(user: User) {
    this.user = { ...user };
  }
}
