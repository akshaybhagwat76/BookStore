import { Component, OnInit, Input } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-table',
  templateUrl: './category-table.component.html',
  styleUrls: ['./category-table.component.css']
})
export class CategoryTableComponent implements OnInit {

  categories: any[] = [];
  editMode = false;
  @Input() creatingMode
  categoryForEditOrCreate: any = {};
  constructor(private categoryService: CategoryService) { }
  tableContainer: any;
  ngOnInit() {
    this.tableContainer = true;
    this.creatingMode = this.categoryService.createMode;
    this.fetch();
  }

  createProductMode() {
    this.tableContainer = false;
    this.categoryForEditOrCreate = {};
    this.creatingMode = !this.creatingMode;
  }

  createCategory() {
    this.creatingMode = !this.creatingMode;
    this.categoryService.createCategory(this.categoryForEditOrCreate).subscribe(x => {
      this.categories = [];

      this.fetch();
      this.categoryForEditOrCreate = {};
      this.creatingMode = false;
      this.tableContainer = true;
    })
  }

  editCategory() {
    this.categoryService.editCategory(this.categoryForEditOrCreate).subscribe(x => {
      this.categories = [];

      this.fetch();
      this.editMode = false;
      this.tableContainer = true;

    })
  }

  selectCategory(categoryName) {
    this.categoryForEditOrCreate.parentName = categoryName;
  }



  editModeForCategory(product) {
    this.tableContainer = false;
    this.categoryForEditOrCreate = {};
    this.creatingMode = false;

    this.categoryForEditOrCreate.name = product.name;
    this.categoryForEditOrCreate.parentName = product.parentName;
    this.categoryForEditOrCreate.Id = product.id;
    this.editMode = !this.editMode;
  }

  deleteCategory(category) {
    this.categoryService.deleteCategory(category.id).subscribe(x => {
      this.categories = [];

      this.fetch();
    })
  }

  fetch() {

    this.categoryService.loadCategoriesWithParents().subscribe((x: Array<any>) => {
      this.categories = [];
      x.forEach(y => {
        this.categories.push(y);
      })
    })
  }
}
interface Category {
  name: string;
  inverseParent: Array<InverseParent>
}
interface InverseParent {
  name: string
}
