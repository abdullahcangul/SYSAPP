import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { HomeComponent } from './main/home.component';
import { BaseDatatableModule } from 'app/core/components/ca-datatable/ca-datatable.module';
import { AddOrUpdateHomeComponent } from './components/add-or-update-home/add-or-update-home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


export const routes:Route[] = [
  {
    path: '',
    component:HomeComponent,
    data: { animation: 'home' }
  },
 
];

@NgModule({
  declarations: [
    HomeComponent,
    AddOrUpdateHomeComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    BaseDatatableModule,
    CardSnippetModule,
    ReactiveFormsModule,
    FormsModule
  ],
})
export class HomeModule { }
