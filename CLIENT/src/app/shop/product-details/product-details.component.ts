import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/_model/IProduct';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  productId!: number;
  product! : IProduct;
  constructor(private shopService: ShopService, private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct()
  {
    // console.log(this.activeRoute.snapshot.paramMap.get('id'))
  
    const id = (this.activeRoute.snapshot.paramMap.get('id'))
    this.shopService.getProduct(id).subscribe(res => {
      this.product = res;
    })
  }
}
