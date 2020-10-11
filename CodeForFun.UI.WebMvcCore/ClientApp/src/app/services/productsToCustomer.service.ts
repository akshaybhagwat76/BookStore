import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsToCustomerService {
isCreationMode = false;
  constructor(private http: HttpClient) { }

  createNewOrder(ord){
    const sub = new Subject<any>();

    this.http.post('/api/ProductsToCustomer/',ord).subscribe(x => {
      sub.next(x)
      sub.complete();
    })
  
    return sub;
  
  }

  update(ord){
    const sub = new Subject<any>();

    this.http.put('/api/ProductsToCustomer/',ord).subscribe(x => {
      sub.next(x)
      sub.complete();
    })
  
    return sub;
  
  }

loadProductsToCustomer(){
  const sub = new Subject<any>();

  this.http.get('/api/ProductsToCustomer/GetAll').subscribe(x => {
    sub.next(x)
  })

  return sub;

}

deleteProductsToCustomer(id){
  const sub = new Subject<any>();

  this.http.delete('/api/ProductsToCustomer?id='+id).subscribe(x => {
    sub.next(x)
    sub.complete();
  })

  return sub;
}

}
