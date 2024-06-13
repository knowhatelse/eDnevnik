import { Observable } from "rxjs";
import { Note } from "../models/response/notes.response.model";

export abstract class INoteService {
    abstract getNotesByStudent(studentId: number): Observable<Note[]>;
}