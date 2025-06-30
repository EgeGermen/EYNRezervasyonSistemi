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

const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  { path: 'home', component: AnaSayfaComponent },
  { path: 'otel-detay', component: OtelDetayComponent },
  { path: 'rezervasyon/oda', component: RezervasyonOdaComponent },
  { path: 'rezervasyon/bilgi', component: RezervasyonBilgiComponent },
  { path: 'rezervasyon/onay', component: RezervasyonOnayComponent },
  { path: 'giris', component: KullaniciGirisComponent },
  { path: 'panel', component: KullaniciPanelComponent },
  { path: 'destek', component: DestekIletisimComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
