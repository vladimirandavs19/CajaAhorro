
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { DashboradComponent } from './dashborad/dashborad.component';



const routes: Routes = [
  {
    path: 'main',
    component: MainComponent,
    children: [
      {path: 'dashboard', component: DashboradComponent, data: {titulo: 'Dashboard'}}
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
   ],
  exports: [RouterModule],
  providers: [],
})
export class PagesRoutingModule {}
