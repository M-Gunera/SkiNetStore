import { Component, OnInit } from '@angular/core';
import { OrdersService } from './orders.service';
import { Order } from '../shared/models/order';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-order-detailed',
  templateUrl: './order-detailed.component.html',
  styleUrls: ['./order-detailed.component.scss']
})

export class OrderDetailedComponent implements OnInit {
  order?: Order;

  constructor(private ordersService: OrdersService, private route: ActivatedRoute, private breadcrumb: BreadcrumbService) { }

  ngOnInit(): void {
    this.getDetailedOrder()
  }

  getDetailedOrder() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) this.ordersService.getSingleOrder(+id).subscribe({
      next: order => {
        this.order = order;
        this.breadcrumb.set('@OrderDetailed', `Order# ${order.id} - ${order.status}`);
      }
    })
  }
}
