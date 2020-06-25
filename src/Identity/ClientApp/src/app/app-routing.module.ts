import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { ClaimsComponent } from './components/claims/claims.component';
import { LoginComponent } from './components/login/login.component';
import { ClaimsGuard } from './core/claims.guard';


const routes: Routes = [
  {
    path: 'register', component: RegisterComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'claims', component: ClaimsComponent, canActivate: [ClaimsGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
