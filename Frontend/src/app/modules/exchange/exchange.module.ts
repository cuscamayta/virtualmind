import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExchangeRoutingModule } from './exchange-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { RateComponent } from './components/rate/rate.component';
import { MatSortModule, MatTableModule } from '@angular/material';
import { PurchaseComponent } from './components/purchase/purchase.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatFormFieldModule, MatInputModule } from '@angular/material';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [RateComponent, PurchaseComponent],
  imports: [
    CommonModule,
    ExchangeRoutingModule,
    TranslateModule,
    MatSortModule,
    MatTableModule,
    MatCardModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatFormFieldModule,
    MatInputModule,
    MatListModule,
    MatIconModule
  ]
})
export class ExchangeModule { }
