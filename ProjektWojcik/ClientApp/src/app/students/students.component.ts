import { Component, OnInit } from '@angular/core';
import { Student } from '../model/student';
import { StudentsService } from '../data-services/students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  students: Student[];
  editedStudent: Student;
  sum: number;
  constructor(private ds: StudentsService) {
    this.students = [];
  }

  ngOnInit() {
    this.students = this.ds.getAll();
    this.compute();
  }

  add() {
    this.editedStudent = new Student();
  }
  delete(student) {

  }
  save() {
    if (this.editedStudent.id == undefined) 
      this.ds.insert(this.editedStudent);
    
    else 
      this.ds.update(this.editedStudent);
    
    this.compute();
    this.editedStudent = null;
  }
  cancel() {
    this.editedStudent = null;
  }
  edit(student) {
    this.editedStudent = Object.assign(new Student(), student);
  }
  compute() {
    this.sum = this.students.reduce((a, currentStudent) => a + parseFloat(currentStudent.Grant.toString()), 0);
  }
}
