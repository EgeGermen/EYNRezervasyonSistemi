import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../user.service';
import { User } from '../user.model';

@Component({
  selector: 'app-ayarlar',
  templateUrl: './ayarlar.component.html',
  styleUrls: ['./ayarlar.component.scss']
})
export class AyarlarComponent implements OnInit {
  user: User = { name: '', email: '', password: '' };
  yeniSifre: string = '';
  yeniSifreTekrar: string = '';
  mesaj: string = '';
  hata: string = '';

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.user = this.userService.getUser();
  }

  kaydet(form?: NgForm) {
    this.hata = '';
    this.mesaj = '';
    if (this.yeniSifre && this.yeniSifre !== this.yeniSifreTekrar) {
      this.hata = 'Şifreler uyuşmuyor!';
      return;
    }
    const guncelUser = { ...this.user };
    if (this.yeniSifre) {
      guncelUser.password = this.yeniSifre;
    }
    this.userService.updateUser(guncelUser);
    this.mesaj = 'Bilgileriniz güncellendi!';
    this.yeniSifre = '';
    this.yeniSifreTekrar = '';
    if (form) form.resetForm({ name: guncelUser.name, email: guncelUser.email, yeniSifre: '', yeniSifreTekrar: '' });
  }
}
