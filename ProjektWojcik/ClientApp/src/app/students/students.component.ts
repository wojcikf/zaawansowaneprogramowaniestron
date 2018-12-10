import { Component, OnInit } from '@angular/core';
import { Student } from '../model/student';
import { StudentsService } from '../data-services/students.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  students: Student[];

  sum: number;
  constructor(private ds: StudentsService) {
    this.students = [];
  }

  ngOnInit() {
    this.students = this.ds.getAll();
    this.compute();
  }

  add() {

  }
  delete(student) {
    this.ds.delete(student);
    this.compute();
  }

  edit(student) {

  }
  compute() {
    this.sum = this.students.reduce((a, currentStudent) => a + parseFloat(currentStudent.Grant.toString()), 0);
  }
}
