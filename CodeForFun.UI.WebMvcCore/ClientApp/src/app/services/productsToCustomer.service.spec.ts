/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProductsToCustomerService } from './productsToCustomer.service';

describe('Service: ProductsToCustomer', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductsToCustomerService]
    });
  });

  it('should ...', inject([ProductsToCustomerService], (service: ProductsToCustomerService) => {
    expect(service).toBeTruthy();
  }));
});
