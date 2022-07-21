import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { IBrand } from '../shared/_model/IBrand';
import { IProduct } from '../shared/_model/IProduct';
import { IType } from '../shared/_model/IType';
import { shopParams } from '../shared/_model/shopParams';
import { ShopService } from './shop.service';



@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  products : IProduct[] = [];
  brands : IBrand[] = [];
  types : IType[] = [];

  shopParams = new shopParams();

  brandIdSelected: number = 0;
  typeIdSelected: number = 0;
  sortSelected = 'name';

  totallCount = 0;

  pageIndex = 0;
  pageSize = 6;

  

  sortOptions = [
    { name: 'Alphabatically', value: 'name'},
    { name: 'Price: Low to High', value: 'sortAsc'},
    { name: 'Price: High to Low', value: 'sortDesc'}
  ]
  

  constructor(private fb: FormBuilder, private shopService: ShopService) { }

  searchFrom = this.fb.group(
    {
      searchKey : ['']
    }
  )

  ngOnInit(): void {
   console.log(this.pageIndex);
   this.getProducts();
   this.getBrands();
   this.getTypes();
  }


  getProducts()
  {
    this.shopService.getProducts(this.shopParams).subscribe(res => {
      this.products = res.data;
      this.shopParams.pageNumber = res.pageIndex;
      this.totallCount = res.count;
      console.log(this.products);
    }, error => {
      console.log(error);
    })
  }

  getTypes()
  {
    this.shopService.getTypes().subscribe(res => {
      this.types = [{id: 0, name :'All'}, ...res];
    })
  }

  getBrands()
  {
    this.shopService.getBrands().subscribe(res => {
      this.brands = [{id: 0, name:'All'}, ...res]
    })
  }

  onBrandSelected(brandId:number)
  {
    this.brandIdSelected = brandId;
    this.shopParams.brandId = brandId;
    console.log(this.shopParams);
    this.getProducts();
  }

  onTypeSelected(typeId: number){
    this.typeIdSelected = typeId;
    this.shopParams.typeId = typeId;
    this.getProducts();
  }

  onSortSelected(event: string)
  {
    this.sortSelected = event;
    this.shopParams.sort = event;
    this.getProducts();
  }

  pageEvent(event: PageEvent)
  {
    console.log(event);
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    console.log(this.pageIndex, this.pageSize);
    this.getProducts();
  }

  onPageChanged(pageIndex: number)
  {
    
    this.shopParams.pageNumber = pageIndex+1;
    this.getProducts();
  }

  searchKey()
  {
    // console.log(this.searchFrom.value.searchKey);
    this.shopParams.search = this.searchFrom.value.searchKey;
    this.getProducts();
  }

  resetAll()
  {
    this.shopParams.search = undefined;
    this.getProducts();
  }
}
