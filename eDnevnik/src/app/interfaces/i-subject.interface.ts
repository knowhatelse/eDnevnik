import { Observable } from "rxjs";
import { Subject } from "../models/response/subject.response.model";

export abstract class ISubjectService {
    abstract getAllSubjects(schoolId: number): Observable<Subject[]>;
}