import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResultVM, StatusEnum } from '../../vms/result.vm';

interface RegisterVM {
  userName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

type ExtractKeys<K extends any> = {
  [P in keyof K]: any;
};

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public readonly originalOrder = (x, y): number => 0;

  public errors: string = '';
  public formGroup: FormGroup;
  public fields: ExtractKeys<RegisterVM>;

  constructor(
    public http: HttpClient,
    public router: Router,
    public fb: FormBuilder,
    @Inject('BASE_URL') public baseUrl: string,
  ) { }

  ngOnInit(): void {
    this.fields = {
      email: ['', Validators.required],
      userName: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    }

    this.formGroup = this.fb.group(this.fields)
  }

  register() {
    this.errors = '';

    this.http
      .post<ResultVM>(this.baseUrl + 'api/account/register', this.formGroup.value)
      .subscribe(
        ({ data, status }) => {
          if (status === StatusEnum.Success) this.router.navigate(['/login']);
          else if (status === StatusEnum.Error) this.errors = data.toString();
        },
        console.error
      );
  }
}
