import { Component, OnInit } from '@angular/core';
import { StudentsService } from '../data-services/students-http.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Student } from '../model/student';
import { Router, ActivatedRoute } from '@angular/router';
//import { FirstLetterUpper } from '../infrastructure/first-letter';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {

  form: FormGroup;

  constructor(private ds: StudentsService, private fb: FormBuilder, private router: Router, private ar: ActivatedRoute) { }

  ngOnInit() {
    this.form = this.fb.group({

      id: this.fb.control(0),
      FirstName: this.fb.control("", Validators.compose([Validators.required, Validators.minLength(3)/*FirstLetterUpper.validate*/])),
      LastName: this.fb.control("", Validators.compose([Validators.required, Validators.minLength(3)])),
      Grant: this.fb.control(0, Validators.compose([Validators.required, Validators.minLength(3)]))
    });

    this.ar.params.subscribe((param) => {

      let id = param['id'];

      if (id) {
        let student = this.ds.findById(id);
        this.form.setValue(Object.assign(new Student(), student));
      }
      else {
        this.form.setValue(new Student());
      }
    });
  }
  
  save() {
    if (this.form.value.id == 0) {
      this.ds.insert(<Student>this.form.value)
        .subscribe((stud) => this.router.navigate(['/students']));
    }
    else {
      this.router.navigate(['/students']);
      this.ds.update(<Student>this.form.value);
    }


  }
  cancel() {

    this.router.navigate(['/students']);

  }
}
