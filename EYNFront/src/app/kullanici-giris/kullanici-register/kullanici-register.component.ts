import { Component } from '@angular/core';
import { UserService } from '../../user.service'; // Yol doğruysa bu şekilde, değilse güncellenebilir

@Component({
  selector: 'app-kullanici-register',
  templateUrl: './kullanici-register.component.html',
  styleUrls: ['./kullanici-register.component.scss']
})
export class KullaniciRegisterComponent {

  kayitAd: string = '';
  kayitEmail: string = '';
  kayitSifre: string = '';
  kayitSifreTekrar: string = '';

  constructor(private userService: UserService) {}

  onRegister() {
    const data = {
      KayitAd: this.kayitAd,
      KayitEmail: this.kayitEmail,
      KayitSifre: this.kayitSifre,
      KayitSifreTekrar: this.kayitSifreTekrar
    };

    this.userService.registerUser(data).subscribe({
      next: res => alert(res.message),
      error: err => console.error(err)
    });
  }
}
