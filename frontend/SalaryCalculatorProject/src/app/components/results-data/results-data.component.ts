import { Component } from '@angular/core';
import { IFormData } from 'src/app/Files/IFormData';
import { SalaryService } from 'src/app/services/salary.service';

@Component({
  selector: 'app-results-data',
  templateUrl: './results-data.component.html',
  styleUrls: ['./results-data.component.css']
})
export class ResultsDataComponent {

  constructor(private salary: SalaryService) { }

  salaryData: number[] = [];
  
  //load data from server
  ngOnInit() {
    this.load_user_data();
  }

  load_user_data() {
    this.salaryData = this.salary.salary_res;
  }



}
