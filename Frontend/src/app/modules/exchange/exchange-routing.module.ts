import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'
import { RateComponent } from './components/rate/rate.component';
import { PurchaseComponent } from './components/purchase/purchase.component';

const routes: Routes = [
  {
    path: '',
    component: RateComponent
  },
  {
    path: 'quote',
    component: RateComponent
  },
  {
    path: 'purchase',
    component: PurchaseComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExchangeRoutingModule { }
