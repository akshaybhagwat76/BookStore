import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  loadCategories() {
    const sub = new Subject<any>();

    this.http.get('/api/product/GetAll').subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;

  }


  loadProducts() {
    const sub = new Subject<any>();

    this.http.get('/api/productdetails/GetAllProducts').subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;

  }

  edit(product) {
    const sub = new Subject<any>();

    this.http.put('/api/product/', product).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;

  }


  editProductDetails(product) {
    const sub = new Subject<any>();

    this.http.put('/api/productdetails/', product).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;

  }

 

  delete(productId) {
    const sub = new Subject<any>();

    this.http.delete('/api/product?productId=' + productId).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }

  deleteProductDetail(productId) {
    const sub = new Subject<any>();

    this.http.delete('/api/productdetails?productId=' + productId).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }

  add(product){
    const sub = new Subject<any>();

    this.http.post('/api/product/',product).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }

  addProductDetail(product) {
    const sub = new Subject<any>();

    this.http.post('/api/productdetails/', product).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }


  getAllProductDetails() {
    const sub = new Subject<any>();

    this.http.get('/api/productdetails/GetAll').subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }
}
