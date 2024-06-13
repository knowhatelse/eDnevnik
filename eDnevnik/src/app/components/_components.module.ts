import { NgModule } from "@angular/core";
import { AbsenceComponent } from "./absence/absence.component";
import { AuthenticationComponent } from "./authentication/authentication.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ExamsComponent } from "./exams/exams.component";
import { GradesComponent } from "./grades/grades.component";
import { HomepageComponent } from "./homepage/homepage.component";
import { NotesComponent } from "./notes/notes.component";
import { RegisterComponent } from "./register/register.component";
import { StudentRuleComponent } from "./student-rule/student-rule.component";
import { VerificationComponent } from "./verification/verification.component";
import { MatDialogModule } from "@angular/material/dialog";
import { ToastrModule } from "ngx-toastr";
import { SharedModule } from "../shared/_shared.module";
import { InformationComponent } from './information/information.component';
import { RedirectionComponent } from './redirection/redirection.component';

@NgModule({
    declarations: [
        AbsenceComponent,
        AuthenticationComponent,
        DashboardComponent,
        ExamsComponent,
        GradesComponent,
        HomepageComponent,
        NotesComponent,
        RegisterComponent,
        StudentRuleComponent,
        VerificationComponent,
        InformationComponent,
        RedirectionComponent
    ],
    exports: [
        AbsenceComponent,
        AuthenticationComponent,
        DashboardComponent,
        ExamsComponent,
        GradesComponent,
        HomepageComponent,
        NotesComponent,
        RegisterComponent,
        StudentRuleComponent,
        VerificationComponent,
        SharedModule
    ],
    imports: [
        SharedModule,
        MatDialogModule,
        ToastrModule.forRoot(),
    ]
})
export class ComponentsModule {

}