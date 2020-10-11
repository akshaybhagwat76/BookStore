import { Component, Inject, Input } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ProductService } from '../services/product.service';
import { CustomerService } from '../services/customer.service';
import { ProductsToCustomerService } from '../services/productsToCustomer.service';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  productsToCustomer: Array<any> = [];
  @Input() creatingMode = false;
  productsToCustomerForEditOrCreate: any = {};
  products: any[] = [];
  customers: any[] = [];
  editMode = false;
  tableContainer: any;

  constructor(private productsToCustomerService: ProductsToCustomerService, private productsService: ProductService, private customerService: CustomerService) { }

  ngOnInit() {
    this.tableContainer = true;
    this.creatingMode = this.productsToCustomerService.isCreationMode;
    this.fetch();
  }

  createProductMode() {
    this.tableContainer = false;
    this.productsToCustomerForEditOrCreate = {};
    this.creatingMode = !this.creatingMode;
  }
  handleError(error: HttpErrorResponse) {
    debugger
    console.log("lalalalalalalala");
    return throwError(error);
  }
  createProductsToCustomer() {
    //debugger
    this.productsToCustomerService.createNewOrder(this.productsToCustomerForEditOrCreate).subscribe(x => {
      debugger
      if (x && x.status === "Failed") {
        alert('Failed to add please select field properly')
      }
      this.productsToCustomer = [];

      this.fetch();
      this.creatingMode = !this.creatingMode;
      this.productsToCustomerForEditOrCreate = null;
      this.productsToCustomerService.isCreationMode = false;
      this.tableContainer = true;

    })


  }

  selectProduct(name) {
    this.productsToCustomerForEditOrCreate.productName = name
  }
  selectCustomer(name) {
    this.productsToCustomerForEditOrCreate.customerName = name
  }

  editModeForProductsToCustomer(productToCustomer) {
    this.productsToCustomerForEditOrCreate.customerName = productToCustomer.customer.name
    this.productsToCustomerForEditOrCreate.Id = productToCustomer.productsToCustomerId
    this.productsToCustomerForEditOrCreate.productName = productToCustomer.product.name
    this.editMode = !this.editMode;
  }

  loadCustomers() {
    this.customerService.getAllCustomers().subscribe(x => {
      this.customers = x;
    })
  }

  editProductToCustomer() {
    this.productsToCustomerService.update(this.productsToCustomerForEditOrCreate).subscribe(x => {
      this.editMode = !this.editMode;
      this.productsToCustomer = [];

      this.fetch();
    })
  }

  loadProducts() {
    this.productsService.loadProducts().subscribe(x => {
      this.products = x;
    })
  }

  errorHandler(error: HttpErrorResponse) {
    debugger
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  }


  deleteProductsToCustomer(productsToCustomerId) {
    debugger
    this.productsToCustomerService.deleteProductsToCustomer(productsToCustomerId).subscribe(x => {
      this.productsToCustomer = [];

      this.fetch();
    })
  }

  fetch() {
    debugger
    this.productsToCustomer = [];
    this.productsToCustomerService.loadProductsToCustomer().subscribe((x: Array<any>) => {
      debugger
      x.forEach(elemet => {
        this.productsToCustomer.push(elemet)
      })
    })
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
