import { enviroment } from './../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer, CommonResponse } from '../models/customer-app';
import { Observable } from 'rxjs/internal/Observable';


@Injectable({
  providedIn: 'root'
})
export class CustomerAppService {

  private url ="Customer";
  constructor(private http: HttpClient) { }

  public getCustomers() : Observable<Customer[]> {
    return this.http.get<Customer[]>(`${enviroment.apiUrl}/${this.url}`);
  }

  /**
   * adds a new customer
   * @params {Customer} data
   * @returns CommonResponse
   */
  public  addCustomer(data: Customer): Observable<CommonResponse> {
    return this.http.post<CommonResponse>(`${enviroment.apiUrl}/${this.url}`, data)
  }


  /**
   * Update Cusomer Info
   *
   * @params {Customer} data
   * @returns CommonResponse
   */
  public updateCustomer(data: Customer): Observable<CommonResponse> {
      return this.http.put<CommonResponse>(
        `${enviroment.apiUrl}/${this.url}`,
        data
      );
  }

  /**
   * Delete a Customer using the attribute Customer?.id
   *
   * @params {Customer} Customer
   * @returns CommonResponse
   */
  public deleteCustomer(Customer: Customer): Observable<CommonResponse> {
    return this.http.delete<CommonResponse>(
      `${enviroment.apiUrl}/${this.url}/${Customer?.id}`,
    );
  }



}
