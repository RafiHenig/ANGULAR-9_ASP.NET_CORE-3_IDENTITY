import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { StateService } from '../../core/state.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
interface LoginVM {
  userName: string;
  password: string;
}

interface ResultVM {
  status: StatusEnum;
  message: string;
  data: {}
}

enum StatusEnum {
  Success = 1,
  Error = 2
}

type ExtractKeys<K extends any> = {
  [P in keyof K]: any;
};


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public readonly originalOrder = (x, y): number => 0;
  public fields: ExtractKeys<LoginVM>;
  public formGroup:FormGroup;
  public errors: string = '';


  constructor(
    public http: HttpClient,
    private fb: FormBuilder,
    public router: Router,
    public stateService: StateService,
    @Inject('BASE_URL') public baseUrl: string,
  ) { }


  ngOnInit(): void {
    this.fields = {
      userName: ['', Validators.required],
      password: ['', Validators.required],
    }

    this.formGroup = this.fb.group(this.fields)
  }

  login() {
    this.errors = '';

    this.http.post<ResultVM>(this.baseUrl + 'api/account/login', this.formGroup.value).subscribe(
      ({ data, status }) => {

        if (status === StatusEnum.Success)
        {
          this.stateService.setAuthentication({ isAuthenticated: true, userName: this.formGroup.value.userName })
          this.router.navigate(['/claims']);
        }
        else if (status === StatusEnum.Error) this.errors = data.toString();

      },
      console.error
    );
  }
}

