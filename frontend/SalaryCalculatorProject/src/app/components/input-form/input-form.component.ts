import { Component } from '@angular/core';
import { IFormData } from 'src/app/Files/IFormData';
import { SalaryService } from 'src/app/services/salary.service';

@Component({
  selector: 'app-input-form',
  templateUrl: './input-form.component.html',
  styleUrls: ['./input-form.component.css']
})
export class InputFormComponent {

  constructor(private salary: SalaryService) { }

  //variables
  isExtraWork = false;
  submittedData: any;
  isSubmitting = false;

  // form default template
  formData: IFormData = {
    jobType: 100,
    experience: 'junior',
    administrationLevel: 0,
    yearsOfExperience: 0,
    ExtraWorkTeam: 'C',
  }
  //form submission
  onSubmit(form: any): void {
    //activate spinner
    this.isSubmitting = true;
    setTimeout(() => {
      this.isSubmitting = false;
    }, 3000);
    
    this.FormValidation();
    console.log('Form Data:', form.value);
  }

  //small logical validation on the form
  FormValidation() {
    if (this.formData.yearsOfExperience > 4 && this.formData.experience == "junior") {
      alert(`junior for ${this.formData.yearsOfExperience} years?`)
      return;
    } else if (this.formData.experience == "junior" && this.formData.administrationLevel != 0) {
      alert("junior running team?")
      return;
    } else {
      this.salary.PostData(this.formData);
    }

  }


}
