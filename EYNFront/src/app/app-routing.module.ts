import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OtelDetayComponent } from './otel-detay/otel-detay.component';
import { RezervasyonOdaComponent } from './rezervasyon-oda/rezervasyon-oda.component';
import { RezervasyonBilgiComponent } from './rezervasyon-bilgi/rezervasyon-bilgi.component';
import { RezervasyonOnayComponent } from './rezervasyon-onay/rezervasyon-onay.component';
import { AnaSayfaComponent } from './ana-sayfa/ana-sayfa.component';
import { KullaniciGirisComponent } from './kullanici-giris/kullanici-giris.component';
import { KullaniciPanelComponent } from './kullanici-panel/kullanici-panel.component';
import { DestekIletisimComponent } from './destek-iletisim/destek-iletisim.component';
import { AyarlarComponent } from './ayarlar/ayarlar.component';
import { KullaniciLoginComponent } from './kullanici-giris/kullanici-login/kullanici-login.component';
import { KullaniciRegisterComponent } from './kullanici-giris/kullanici-register/kullanici-register.component';
import { AdminLoginComponent } from './kullanici-giris/admin-login/admin-login.component';

const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  { path: 'home', component: AnaSayfaComponent },
  { path: 'otel-detay', component: OtelDetayComponent },
  { path: 'rezervasyon/oda', component: RezervasyonOdaComponent },
  { path: 'rezervasyon/bilgi', component: RezervasyonBilgiComponent },
  { path: 'rezervasyon/onay', component: RezervasyonOnayComponent },
  { path: 'kullanici-giris', component: KullaniciGirisComponent,
    children: [
      {path: 'login', component: KullaniciLoginComponent},
      {path: 'register', component: KullaniciRegisterComponent},
      {path: 'login', component: AdminLoginComponent}
    ]
   },
  { path: 'panel', component: KullaniciPanelComponent },
  { path: 'destek', component: DestekIletisimComponent },
  { path: 'ayarlar', component: AyarlarComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
