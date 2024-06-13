import { Observable } from "rxjs";
import { Absence } from "../models/response/absence.response.model";

export abstract class IAbsenceService {
    abstract getAbsencesByStudent(studentId: number): Observable<Absence[]>
}