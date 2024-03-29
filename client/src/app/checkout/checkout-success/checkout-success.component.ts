import { Component } from '@angular/core';
import { CheckoutService } from '../checkout.service';
import { Router } from '@angular/router';
import { OrdersService } from 'src/app/orders/orders.service';
import { Order } from 'src/app/shared/models/order';

@Component({
  selector: 'app-checkout-success',
  templateUrl: './checkout-success.component.html',
  styleUrls: ['./checkout-success.component.scss']
})
export class CheckoutSuccessComponent {
  order?: Order;

  constructor(private router: Router) { 
    const navigation = this.router.getCurrentNavigation();
    this.order = navigation?.extras?.state as Order;
  }

}
