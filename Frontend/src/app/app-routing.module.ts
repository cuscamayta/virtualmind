import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [  
  {
    path: '',
    loadChildren: () => import('./modules/exchange/exchange.module').then(m => m.ExchangeModule)
  },
  {
    path: 'exchange',
    loadChildren: () => import('./modules/exchange/exchange.module').then(m => m.ExchangeModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
