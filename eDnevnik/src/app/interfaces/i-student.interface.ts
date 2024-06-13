import { Observable } from "rxjs";
import { Student } from "../models/response/student.response.model";

export abstract class IStudentService {
    abstract getStudentById(id: number): Observable<Student>;
}