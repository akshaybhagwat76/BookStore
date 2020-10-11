import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders: Array<Order> = [];
  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderService.productId == null ? this.orderService.loadCategories().subscribe((x: Array<Order>) => {
      console.log(x);
      x.forEach(elemet => {
        this.orders.push(elemet)
      })
    }) :
      this.orderService.getOrdersByProduct(this.orderService.productId).subscribe((x: Array<Order>) => {
        x.forEach(elemet => {
          this.orders.push(elemet)
        })
      })
  }

}
interface Order {
  code?: string;
  name?: string;
  unitPrice?: any;
  dateRegister?: any;
  isActive?: boolean;
  categoryName?: string;
  description: string;
  nameOfEmployer: string;
  surnameOfEmployer: string;
}
