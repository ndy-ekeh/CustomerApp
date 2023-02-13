import { CustomerAppService } from './services/customer-app.service';
import { Customer } from './models/customer-app';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  customer: Customer[] = [];
  CustomerToEdit?: Customer;
  IsNewCustomer: boolean = false;

  constructor(private CustomerAppService: CustomerAppService){}

  ngOnInit() : void {
    this.CustomerAppService
    .getCustomers()
    .subscribe((result: Customer[]) => {
      this.customer = result
    });
  }
  initNewCustomer(){
    this.CustomerToEdit = new Customer();
    this.IsNewCustomer = true;
  }

  editCustomer(Customer: Customer){
    this.CustomerToEdit = Customer;
    this.IsNewCustomer = false;
  }
}
