import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { ClaimsComponent } from './components/claims/claims.component';
import { LoginComponent } from './components/login/login.component';
import { Authenticated } from './core/authenticated.guard';
import { HomeComponent } from './components/home/home.component';
import { UsersComponent } from './components/users/users.component';
import { AdminGuard } from './core/admin.guard';
import { StreamingComponent } from './components/videos/streaming.component';
import { StreamingRegisterComponent } from './components/videos/streaming-register/streaming-register.component';
import { StreamingAddComponent } from './components/videos/streaming-add/streaming-add.component';


const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [Authenticated] },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'claims', component: ClaimsComponent, canActivate: [Authenticated] },
  { path: 'users', component: UsersComponent, canActivate: [Authenticated, AdminGuard] },
  { path: 'videos/:id', component: StreamingComponent },
  { path: 'videos', component: StreamingComponent },
  { path: 'streaming/register', component: StreamingRegisterComponent },
  { path: 'streaming/videos/add', component: StreamingAddComponent },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
