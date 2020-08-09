import { Component, OnInit, Inject, ViewContainerRef } from '@angular/core';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { Router } from '@angular/router';
import { StreamingCategoryVM } from '../../../core/domain';

@Component({
  selector: 'app-streaming-register',
  templateUrl: './streaming-register.component.html',
  styleUrls: ['./streaming-register.component.css']
})
export class StreamingRegisterComponent {
  public categories: StreamingCategoryVM[] = [];
  public checkedAll: boolean = false;
  public displayVideoForm: boolean = false;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string,
    private router: Router, vcr: ViewContainerRef) {

    this.http.get<StreamingCategoryVM[]>(this.baseUrl + 'api/streaming/videos/register').subscribe(x => {
      this.categories = x
      console.log(this.categories);
    }, error => console.error(error));

  }

  toggleCategories($event: any) {
    var check = $event.target.checked;

    this.categories.forEach(c => c.registered = check);
  }

  toggleCategory(category: StreamingCategoryVM) {
    category.registered = !category.registered;

    if (!category.registered)
    {
      this.checkedAll = false;
    }
  }

  update() {
    var categories = this.categories.filter(c => c.registered === true).map(c => c.category);
    this.http.post(this.baseUrl + 'api/streaming/videos/register',categories).subscribe(console.log, console.error);
  }

  viewCategory(event: any, category: string) {
    event.stopPropagation();
    this.router.navigate(['/videos', category]);
  }
}

