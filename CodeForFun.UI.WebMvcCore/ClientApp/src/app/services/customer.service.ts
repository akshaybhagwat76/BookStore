import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  editProductDetails(product) {
    const sub = new Subject<any>();

    this.http.put('/api/customers/', product).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;

  }
  getAllCustomers() {
    const sub = new Subject<any>();

    this.http.get('/api/customers/GetAll').subscribe(x => {
      sub.next(x)
    })

    return sub;
  }
  deleteProductDetail(productId) {
    const sub = new Subject<any>();

    this.http.delete('/api/customers?id=' + productId).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }
  addProductDetail(product) {
    const sub = new Subject<any>();

    this.http.post('/api/customers/', product).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }


  getAllProductDetails() {
    debugger
    const sub = new Subject<any>();

    this.http.get('/api/customers/GetAll').subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }
}
