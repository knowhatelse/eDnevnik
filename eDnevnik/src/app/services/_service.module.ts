import { NgModule } from "@angular/core";
import { IAbsenceService } from "../interfaces/i-absence.interface";
import { AbsenceService } from "./absence.service";
import { IAccountService } from "../interfaces/i-account.interface";
import { AccountService } from "./account.service";
import { IConfigurationService } from "../interfaces/i-configuration.interface";
import { ConfigurationService } from "./configuration.service";
import { IExamService } from "../interfaces/i-exam.interface";
import { ExamService } from "./exam.service";
import { IGradeService } from "../interfaces/i-grade.interface";
import { GradeService } from "./grade.service";
import { INavigationService } from "../interfaces/i-navigation.interface";
import { NavigationService } from "./navigation.service";
import { INoteService } from "../interfaces/i-note.interface";
import { NoteService } from "./note.service";
import { IParentService } from "../interfaces/i-parent.interface";
import { ParentService } from "./parent.service";
import { IStorageService } from "../interfaces/i-storage.interface";
import { StorageService } from "./storage.service";
import { IStudentRuleService } from "../interfaces/i-student-rule.interface";
import { StudentRuleService } from "./student-rule.service";
import { IStudentService } from "../interfaces/i-student.interface";
import { StudentService } from "./student.service";
import { ISubjectService } from "../interfaces/i-subject.interface";
import { SubjectService } from "./subject.service";
import { ITokenService } from "../interfaces/i-token.interface";
import { TokenService } from "./token.service";

@NgModule({
    providers: [
        { provide: IAbsenceService, useClass: AbsenceService },
        { provide: IAccountService, useClass: AccountService },
        { provide: IConfigurationService, useClass: ConfigurationService },
        { provide: IExamService, useClass: ExamService },
        { provide: IGradeService, useClass: GradeService },
        { provide: INavigationService, useClass: NavigationService },
        { provide: INoteService, useClass: NoteService },
        { provide: IParentService, useClass: ParentService },
        { provide: IStorageService, useClass: StorageService },
        { provide: IStudentRuleService, useClass: StudentRuleService },
        { provide: IStudentService, useClass: StudentService },
        { provide: ISubjectService, useClass: SubjectService },
        { provide: ITokenService, useClass: TokenService },
    ]
})
export class ServiceModule {
    
}