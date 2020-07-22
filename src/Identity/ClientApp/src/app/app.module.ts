import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { ClaimsComponent } from './components/claims/claims.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AppComponent } from './components/app/app.component';
import { NavComponent } from './components/nav/nav.component';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './core/http.interceptor';
import { UsersComponent } from './components/users/users.component';
import { StreamingComponent  } from './components/videos/streaming.component';
import { StreamingRegisterComponent } from './components/videos/streaming-register/streaming-register.component';
import { StreamingAddComponent } from './components/videos/streaming-add/streaming-add.component';

@NgModule({
  declarations: [
    AppComponent,
    ClaimsComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    NavComponent,
    UsersComponent,
    StreamingComponent,
    StreamingRegisterComponent,
    StreamingAddComponent ,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    MatToolbarModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

