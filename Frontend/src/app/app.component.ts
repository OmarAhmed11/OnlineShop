import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './Models/product';
import { Pagination } from './Models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Hello Omar';
  products: Product[] = []
  prodCount : number = 0;
  constructor(private http: HttpClient) {

  }
  ngOnInit(): void {
    this.http.get<Pagination<Product>>(`https://localhost:5001/api/Products?PageSize=5`,).subscribe(
      {
        next: res => { console.log(res) , this.products = res.data, this.prodCount = res.count},
        error: err => alert(err),
        complete: () => console.log("Done Perfect")
      }
    )
    // this.http.get(`https://localhost:5001/api/Products/${2}`,).subscribe(
    //   {
    //     next: res => { console.log(res) },
    //     error: err => alert(err),
    //     complete: () => console.log("Done Perfect")
    //   }
    // )
  }
}
