import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Note } from '../models/response/notes.response.model';
import { Observable } from 'rxjs';
import { GET_NOTES_BY_STUDENT } from '../shared/api-url.shared';
import { INoteService } from '../interfaces/i-note.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class NoteService implements INoteService {

  constructor(private httpClient: HttpClient, private config: IConfigurationService) { }

  getNotesByStudent(studentId: number): Observable<Note[]> {
    return this.httpClient.get<Note[]>(this.config.getBaseUrl() + GET_NOTES_BY_STUDENT + studentId, {headers: this.config.getHeaders()});
  }
}
