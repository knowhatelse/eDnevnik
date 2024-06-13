import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from '../models/response/subject.response.model';
import { GET_ALL_SUBJECTS } from '../shared/api-url.shared';
import { Observable } from 'rxjs';
import { ISubjectService } from '../interfaces/i-subject.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class SubjectService implements ISubjectService {

  constructor(private httpClient: HttpClient, private config: IConfigurationService) { }

  getAllSubjects(schoolId: number): Observable<Subject[]> {
    return this.httpClient.get<Subject[]>(this.config.getBaseUrl() + GET_ALL_SUBJECTS + schoolId, {headers: this.config.getHeaders()});
  }
}
