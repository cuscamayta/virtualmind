import { Component, OnInit } from '@angular/core';

export interface Section {
  name: string;
  updated: Date;
}

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss']
})
export class PurchaseComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  folders: Section[] = [
    {
      name: 'USD: 150',
      updated: new Date('1/1/16'),
    },
    {
      name: 'BRL: 40',
      updated: new Date('1/17/16'),
    },
    {
      name: 'USD: 120',
      updated: new Date('1/28/16'),
    }
  ];

}
