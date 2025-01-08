import { HttpClient } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SalaryService {

  constructor(private http: HttpClient, private router: Router) { }

  salary_res: any;
  url = "http://localhost:5204/Salary/IncreaseSalaryCalc";

  PostData(UserInputData: any) {
    this.http.post(this.url, UserInputData, { observe: "response" }).
      subscribe({

        next: (res) => {              
          this.salary_res = res.body;//saving response in local variable
          console.log(this.salary_res)
          this.router.navigate(['/results'])//nav to results component to view data

        },
        error: (err) => {
          //catch errors
          alert("An error occurred. Please make sure the server is running and try again.");
          console.error(err)
        },
        complete: () => {
          console.log("data retrived successfully")
        }

      })


  }


}
