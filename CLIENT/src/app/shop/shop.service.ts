import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { IPagination } from '../shared/_model/IPagination';
import { IBrand } from '../shared/_model/IBrand';
import { IType } from '../shared/_model/IType';
import { delay, map } from 'rxjs';
import { shopParams } from '../shared/_model/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:7014/api/';

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
  
  constructor(private http: HttpClient) { }

  getProducts(shopParams: shopParams)
  {
    let params = new HttpParams();
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    
    if(shopParams.brandId !== 0){
      params = params.append('BrandId', shopParams.brandId.toString());
    }

    if(shopParams.typeId !== 0)
    {
      params = params.append('TypeId', shopParams.typeId.toString());
    }

    if(shopParams.search != undefined){
      params = params.append('Search', shopParams.search);
    }
    params = params.append('Sort', shopParams.sort);
    params = params.append('PageIndex', shopParams.pageNumber);
    params = params.append('PageSize', shopParams.pageSize);
    
    
    return this.http.get<IPagination>(this.baseUrl + "Products", {observe: 'response', params})
      .pipe(
        delay(500),
        map((response: { body: any; }) => {
          return response.body;
        })
      );
  }

  getBrands()
  {
    return this.http.get<IBrand[]>(this.baseUrl + 'Products/brands', this.httpOptions);
  }

  getTypes()
  {
    return this.http.get<IType[]>(this.baseUrl + 'Products/types', this.httpOptions);
  }
}
