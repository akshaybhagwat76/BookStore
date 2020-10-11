import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { OrderService } from '../services/order.service';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  products: Array<Product> = [];
  filteredProducts: Array<Product> = [];
  isOrdersShow = false;
  isProductsShow;
  editMode = false;
  creatingMode = false;
  categoryName;
  tableContainer: any;
  lstProducts: any;
  productForEditOrCreate: any = {};

  constructor(private productService: ProductService, private orderService: OrderService, private customerService: CustomerService) {
  }

  ngOnInit() {
    this.tableContainer = true;
    this.isProductsShow = true;
    this.isOrdersShow = true;
    this.fetch();
  }

  editModeForProduct(product) {
    this.editMode = !this.editMode;
    this.isOrdersShow = false;

    this.productForEditOrCreate = product;
  }

  editProduct() {
    this.customerService.editProductDetails(this.productForEditOrCreate).subscribe(x => {
      this.editMode = false;
      this.isOrdersShow = true;
      this.products = [];
      this.fetch();
    })
  }


  selectCategory($event) {
    this.filteredProducts = this.products;

    if ($event != "All") {
      this.filteredProducts = this.filteredProducts.filter(x => {
        return x.categoryName == $event;
      })
    }

  }

  getOrdersByProduct(productId) {
    this.orderService.productId = productId;
    this.OrdersMode("");
  }

  createProductMode() {
    this.tableContainer = false;
    this.productForEditOrCreate = {};
    this.creatingMode = !this.creatingMode;
  }

  OrdersMode(orderMode) {
    if (orderMode == "getAll")
      this.orderService.productId = null;

    this.isOrdersShow = !this.isOrdersShow;
    this.isProductsShow = !this.isProductsShow;
  }
  deleteProductDetail(productId) {
    this.customerService.deleteProductDetail(productId).subscribe(x => {
      this.products = [];

      this.fetch();
    })
  }

  fetch() {
    this.customerService.getAllProductDetails().subscribe((x: []) => {
      this.products = x;
      this.filteredProducts = x;
    })
  }

  saveSelectedCategory($event) {
    this.categoryName = $event;
  }

  createCustomer() {
    this.customerService.addProductDetail(this.productForEditOrCreate).subscribe(x => {
      this.products = [];
      this.fetch();
      this.creatingMode = false;
      this.tableContainer = true;
    })
    

     

  }
}
interface Product {
  id: any;
  code?: string;
  name?: string;
  unitPrice?: any;
  dateRegister?: any;
  isActive?: boolean;
  categoryName?: string;
}
