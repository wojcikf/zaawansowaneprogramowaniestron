import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { StudentsComponent } from './students/students.component';
import { FirstComponent } from './first/first.component';
//import { StudentsService } from './data-services/students.service';
//import { StudentsLsService } from './data-services/students-ls.service';
import { StudentsService } from './data-services/students-http.service';
import { StudentFormComponent } from './student-form/student-form.component';


@NgModule({
  declarations: [
    AppComponent,
    StudentsComponent,
    FirstComponent,
    StudentFormComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'students', pathMatch: 'full' },
      {
        path: 'students', component: StudentsComponent, children: [
          { path: 'create', component: StudentFormComponent },
          { path: ':id/edit', component: StudentFormComponent }
        ]
      },
      { path: '**', redirectTo: 'students' },
    ])
  ],
  providers: [{ provide: StudentsService, useClass:StudentsService}],
  bootstrap: [AppComponent]
})
export class AppModule { }
