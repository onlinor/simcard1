import { Component, OnInit } from '@angular/core';
import { ShopService } from '../../../../Services/Shop.service';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent implements OnInit {
  model: any = {};

  constructor(private shopservice: ShopService) { }

  ngOnInit() {
  }

  addProduct() {
    this.shopservice.AddProduct(this.model).subscribe(next => {
      console.log('login successfully!!!');
    }, error => {
      console.log('failed to login');
    });
  }

}
