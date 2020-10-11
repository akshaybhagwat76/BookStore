import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { RecaptchaModule, RecaptchaFormsModule } from 'ng-recaptcha';
import { RECAPTCHA_V3_SITE_KEY, RecaptchaV3Module } from 'ng-recaptcha';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProductsComponent } from './products/products.component';
import { CategoryComponent } from './category/category.component';
import { CategoryService } from './services/category.service';
import { ProductService } from './services/product.service';
import { SocialLoginModule, AuthServiceConfig } from "angularx-social-login";
import { GoogleLoginProvider, FacebookLoginProvider } from "angularx-social-login";
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AccountService } from './services/account.service';
import { OrdersComponent } from './orders/orders.component';
import { OrderService } from './services/order.service';
import { ProductsDetailsComponent } from './productdetails/productdetails.component';
import { CustomerService } from './services/customer.service';
import { CustomerComponent } from './customer/customer.component';
import { CategoryTableComponent } from './category/category-table/category-table.component';
import { ProductsToCustomerService } from './services/productsToCustomer.service';


let config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider("735335157823-lqpobanqtlfh05sb2fje2ltskp906nqs.apps.googleusercontent.com")
  },
  {
    id: FacebookLoginProvider.PROVIDER_ID,
    provider: new FacebookLoginProvider("2587514881515393")
  }
]);

export function provideConfig() {
  return config;
}

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      CounterComponent,
      FetchDataComponent,
    ProductsComponent,
    ProductsDetailsComponent,
      CategoryComponent,
      OrdersComponent,
      LoginComponent,
    RegisterComponent,
    OrdersComponent, CustomerComponent,
    CategoryTableComponent
   ],
   imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RecaptchaModule,
    RecaptchaFormsModule,
    SocialLoginModule,
    RecaptchaV3Module,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'products', component: ProductsComponent },
      { path: 'category', component: CategoryComponent },
      { path: 'productdetails', component: ProductsDetailsComponent },
      { path: 'customers', component: CustomerComponent },
      { path: 'customertable', component: CategoryTableComponent },
      { path: 'home', component: CustomerComponent },
      { path: 'fetch-data', component: FetchDataComponent }


    ])
  ],
  providers: [
    // { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    // { provide: RECAPTCHA_V3_SITE_KEY, useValue: '6LdjaOAUAAAAADxWsshY0Oq5nJNv744g36l6fwnj' },
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    },
    CategoryService,
    ProductService,
    AccountService,
    OrderService,
    CustomerService,
    ProductsToCustomerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
