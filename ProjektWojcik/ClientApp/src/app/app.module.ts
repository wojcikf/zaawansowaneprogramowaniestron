import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FirstComponent } from './first/first.component';
import { StudentsService } from './data-services/students.service';
import { StudentsLsService } from './data-services/students-ls.service';
import { StudentFormComponent } from './student-form/student-form.component';

@NgModule({
  declarations: [
    AppComponent,
    FirstComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'students', pathMatch: 'full' },
      { path: 'students', component: StudentsComponent },
      { path: 'students/create', component: StudentFormComponent },
      { path: '**', redirectTo: 'students' },
    ])
  ],
  providers: [{ provide: StudentsService, useClass:StudentsLsService}],
  bootstrap: [AppComponent]
})
export class AppModule { }
