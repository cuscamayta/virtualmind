import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort, MatTableDataSource } from '@angular/material';
import { TranslateService } from '@ngx-translate/core';
import { UserNotificationService, UserNotificationType } from 'src/app/core/services/user-notification/user-notification.service';
import { ExchangeService } from '../../services/exchange.service';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}



@Component({
  selector: 'app-rate',
  templateUrl: './rate.component.html',
  styleUrls: ['./rate.component.scss']
})
export class RateComponent implements AfterViewInit {

  constructor(private exchangeService: ExchangeService,
    private userNotification: UserNotificationService,
    private translate: TranslateService) { }

  exchanges: any = {
    usd: {
      purchase: 92.750,
      sell: 98.750,
      lastModified: "Actualizada al 5/5/2021 11:30"
    },
    brl: {
      purchase: 20.750,
      sell: 18.750,
      lastModified: "Actualizada al 5/5/2021 11:30"
    }
  };


  ngAfterViewInit() {
    this.loadCurrencyExchange();
  }

  loadCurrencyExchange() {
    this.exchangeService.fetchRateExchange('USD').subscribe(response => {
      this.exchanges.usd = response.result;
      this.showNotification('validation.messages.retrieve', UserNotificationType.Sucess);
    }, error => {
      console.log('error')
      this.showNotification('validation.messages.badGetInformation', UserNotificationType.Error);
    });

    this.exchangeService.fetchRateExchange('BRL').subscribe(response => {
      this.exchanges.brl = response.result;
      this.showNotification('validation.messages.retrieve', UserNotificationType.Sucess);
    }, error => {
      this.showNotification('validation.messages.badGetInformation', UserNotificationType.Error);
    })
  }

  showNotification(message, typeNotification) {
    this.translate.get(message).subscribe((text: string) => {
      this.userNotification.showMessage(text, typeNotification);
    });
  }

}
