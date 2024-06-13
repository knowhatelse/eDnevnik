import { Observable } from "rxjs";
import { Exams } from "../models/response/exams.response.model";

export abstract class IExamService {
    abstract getExamsByDepartment(departmentId: number): Observable<Exams[]>;
}