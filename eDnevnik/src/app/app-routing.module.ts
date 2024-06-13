import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import { GradesComponent } from './components/grades/grades.component';
import { ExamsComponent } from './components/exams/exams.component';
import { AbsenceComponent } from './components/absence/absence.component';
import { NotesComponent } from './components/notes/notes.component';
import { StudentRuleComponent } from './components/student-rule/student-rule.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RouteGuard } from './guards/route.guard';
import { InformationComponent } from './components/information/information.component';
import { RedirectionComponent } from './components/redirection/redirection.component';

const routes: Routes = [
  { path: '', component: HomepageComponent},
  { path: 'information', component: InformationComponent, canActivate: [RouteGuard], data: {expectedRole: ['Student', 'Parent', 'Admin', 'Teacher']}},
  { path: 'dashboard', component: DashboardComponent, canActivate: [RouteGuard], data: {expectedRole: ['Student', 'Parent']} },
  { path: 'grades', component: GradesComponent, canActivate: [RouteGuard], data: {expectedRole: ['Student', 'Parent']} },
  { path: 'exams', component: ExamsComponent, canActivate: [RouteGuard], data: {expectedRole: ['Student', 'Parent']} },
  { path: 'absences', component: AbsenceComponent, canActivate: [RouteGuard], data: {expectedRole: ['Student', 'Parent']} },
  { path: 'notes', component: NotesComponent, canActivate: [RouteGuard], data: {expectedRole: ['Student', 'Parent']} },
  { path: 'student-rule', component: StudentRuleComponent, canActivate: [RouteGuard], data: {expectedRole: ['Student', 'Parent']} },
  { path: '**', component: RedirectionComponent, canActivate: [RouteGuard], data: {expectedRole: ['Student', 'Parent', 'Admin', 'Teacher']} }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
