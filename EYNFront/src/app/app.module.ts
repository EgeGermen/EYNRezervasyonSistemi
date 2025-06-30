import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OtelDetayComponent } from './otel-detay/otel-detay.component';
import { RezervasyonOdaComponent } from './rezervasyon-oda/rezervasyon-oda.component';
import { RezervasyonBilgiComponent } from './rezervasyon-bilgi/rezervasyon-bilgi.component';
import { RezervasyonOnayComponent } from './rezervasyon-onay/rezervasyon-onay.component';
import { AnaSayfaComponent } from './ana-sayfa/ana-sayfa.component';
import { KullaniciPanelComponent } from './kullanici-panel/kullanici-panel.component';
import { DestekIletisimComponent } from './destek-iletisim/destek-iletisim.component';
import { KullaniciGirisComponent } from './kullanici-giris/kullanici-giris.component';

@NgModule({
  declarations: [
    AppComponent,
    OtelDetayComponent,
    RezervasyonOdaComponent,
    RezervasyonBilgiComponent,
    RezervasyonOnayComponent,
    AnaSayfaComponent,
    KullaniciPanelComponent,
    DestekIletisimComponent,
    KullaniciGirisComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
