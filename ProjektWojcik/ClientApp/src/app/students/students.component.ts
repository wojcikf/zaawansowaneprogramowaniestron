import { Component, OnInit, OnDestroy } from '@angular/core';
import { Student } from '../model/student';
import { StudentsService } from '../data-services/students-http.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit, OnDestroy {

  students: Student[];

  sum: number;
  subs: Subscription;
  constructor(private ds: StudentsService) {
    this.students = [];
  }

  ngOnInit() {
    this.ds.getAll().subscribe((students) => {
      this.students = students;
      this.compute();
    });
    this.ds.onResult.subscribe(student => { this.students.push(student) });
    this.compute();
  }

  delete(student) {
  //  this.ds.onResult.subscribe(student => { this.students.(student) });

    this.compute();
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  compute() {
    this.sum = this.students.reduce((a, currentStudent) => a + parseFloat(currentStudent.Grant.toString()), 0);
  }
}
