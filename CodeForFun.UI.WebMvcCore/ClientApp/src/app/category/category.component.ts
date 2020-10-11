import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  @Input() categories:Array<Category> = [];
  @Output()selectedCategory = new EventEmitter();

  constructor(private categoryService:CategoryService) { }

  ngOnInit() {
    debugger
    this.categoryService.loadCategories().subscribe((x:Array<Category>)=>{
      x.forEach(y=>{
        this.categories.push(y);
      })
    })
  }

  selectCategory(categoryName){
    this.selectedCategory.emit(categoryName);
  }
}
interface Category{
   name:string;
   inverseParent:Array<InverseParent> 
}
interface InverseParent{
  name:string
}
