import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InputFormComponent } from './components/input-form/input-form.component';
import { ResultsDataComponent } from './components/results-data/results-data.component';

const routes: Routes = [
  { path: 'form', component: InputFormComponent },
  { path: 'results', component: ResultsDataComponent },
  { path: '**', component: InputFormComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
