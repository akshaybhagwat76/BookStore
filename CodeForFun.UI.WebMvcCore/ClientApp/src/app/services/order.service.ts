import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
productId;

constructor(private http: HttpClient) { }

  getOrdersByProduct(id) {
    console.log(id)
    const sub = new Subject<any>();

    this.http.get('/api/Order?id='+id).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;

  }

  loadCategories() {
    const sub = new Subject<any>();

    this.http.get('/api/order/getAll').subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;

  }

}
