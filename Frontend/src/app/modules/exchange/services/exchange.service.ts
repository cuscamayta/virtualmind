import { Injectable } from '@angular/core';
import { DataService } from 'src/app/core/services/data/data.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {
  entityName = 'exchange';
  constructor(private dataService: DataService) { }

  fetchRateExchange(currencyCode): Observable<any> {
    return this.dataService.get(`${this.entityName}/rate/${currencyCode}`);
  }

  fetchStudentsByName(studentName: string): Observable<any> {
    return this.dataService.get(`${this.entityName}/${studentName}`);
  }
}
