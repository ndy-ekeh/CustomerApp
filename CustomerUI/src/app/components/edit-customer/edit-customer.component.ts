import { Customer } from './../../models/customer-app';
import { Component,Input,OnInit } from '@angular/core';
import { CustomerAppService } from 'src/app/services/customer-app.service';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit{
  @Input() Customer?: Customer;

  @Input() isNewCustomer!: boolean;

  /**
   * Injects the customer Service into EditCustomerComponent
   */
  constructor(private customerService: CustomerAppService) {

  }
  ngOnInit(): void {

  }


  updateCustomer(Customer:Customer) {
    this.customerService.updateCustomer(Customer)
    .toPromise()
    .then(res => location.reload())
  }

  deleteCustomer(Customer: Customer) {
    this.customerService
      .deleteCustomer(Customer)
      .toPromise()
      .then((res) => location.reload());
  }

  createCustomer(Customer:Customer) {
  this.customerService
    .addCustomer(Customer)
    .toPromise()
    .then((res) => location.reload());
  }

  get checkIfCustomerNew() {
    return this.Customer?.firstName == '' &&
     this.Customer?.firstName == '' &&
     this.Customer?.email == "" &&
     this.Customer.accountNumber == "" &&
     this.Customer.houseAddress == "" &&
     this.Customer.phoneNo == ""
  }

}
