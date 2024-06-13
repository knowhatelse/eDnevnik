import { Observable } from "rxjs";
import { Grade } from "../models/response/grades.response.model";

export abstract class IGradeService {
    abstract getStudentGrades(studentId: number): Observable<Grade[]> 
}