import { Observable } from "rxjs";
import { StudentRule } from "../models/response/student-rule.response.model";

export abstract class IStudentRuleService {
    abstract getStudentRuleByStudent(studentId: number): Observable<StudentRule[]>;
}