import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

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
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AyarlarComponent } from './ayarlar/ayarlar.component';
import { UserService } from './user.service';

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
    KullaniciGirisComponent,
    HeaderComponent,
    FooterComponent,
    AyarlarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
