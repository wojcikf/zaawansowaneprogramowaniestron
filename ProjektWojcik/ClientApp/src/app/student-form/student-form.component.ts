import { Component, OnInit } from '@angular/core';
import { StudentsService } from '../data-services/students.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Student } from '../model/student';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {

  form: FormGroup;

  constructor(private ds: StudentsService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.form = this.fb.group({

      id: this.fb.control(0),
      FirstName: this.fb.control("", Validators.compose([Validators.required, Validators.minLength(3)])),
      LastName: this.fb.control("", Validators.compose([Validators.required, Validators.minLength(3)])),
      Grant: this.fb.control(0, Validators.compose([Validators.required, Validators.minLength(3)]))
    });
  }

  save() {
    if (this.form.value.id == 0) {
      this.ds.insert(<Student>this.form.value);
      this.router.navigate(['/students']);
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
