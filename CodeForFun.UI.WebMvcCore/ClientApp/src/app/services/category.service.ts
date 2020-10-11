import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }
  createMode = false;

  loadCategories() {
    const sub = new Subject<any>();

    this.http.get('/api/category/GetAll').subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;

  }

  createCategory(category) {
    const sub = new Subject<any>();

    this.http.post('/api/category', category).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }

  deleteCategory(categoryName) {
    const sub = new Subject<any>();

    this.http.delete('/api/category?id=' + categoryName).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }


  editCategory(category) {
    const sub = new Subject<any>();

    this.http.put('/api/category', category).subscribe(x => {
      sub.next(x)
      sub.complete();
    })

    return sub;
  }

  loadCategoriesWithParents() {
    const sub = new Subject<any>();

    this.http.get('/api/category/GetAllWithParents').subscribe(x => {
      sub.next(x)
    })

    return sub;

  }
}
