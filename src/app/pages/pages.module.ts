import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { AppRoutingModule } from '../app-routing.module';
import { MainComponent } from './main/main.component';
import { DashboradComponent } from './dashborad/dashborad.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ErrorComponent } from './error/error.component';



@NgModule({
  declarations: [
    MainComponent,
    DashboradComponent,
    NotfoundComponent,
    ErrorComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AppRoutingModule
  ]
})
export class PagesModule { }
