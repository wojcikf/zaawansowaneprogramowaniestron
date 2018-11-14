import { Injectable } from '@angular/core';
import { Student } from '../model/student';

@Injectable()
export class StudentsService {

  collection: Student[] = [];
  nextId: number = 1;
  constructor() { }

  getAll() {

    return this.collection;
  }
  findById(id: number) {
    return this.collection.find(x => x.id == id)
  }
  insert(student: Student) {
    student.id = this.nextId++;
    this.collection.push(student);
  }
  update(student: Student) {
    let stud= this.findById(student.id);
    Object.assign(stud, student);
  }
  delete(student: Student) {
    let stud = this.findById(student.id);
    this.collection.pop();
  }
}
