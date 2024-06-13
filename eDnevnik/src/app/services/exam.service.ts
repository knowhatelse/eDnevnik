import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Exams } from '../models/response/exams.response.model';
import { Observable } from 'rxjs';
import { GET_EXAMS_BY_DEPARTMENT } from '../shared/api-url.shared';
import { IExamService } from '../interfaces/i-exam.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class ExamService implements IExamService {

  constructor(private httpClient: HttpClient, private config: IConfigurationService) {
  }

  getExamsByDepartment(departmentId: number): Observable<Exams[]> {
    return this.httpClient.get<Exams[]>(this.config.getBaseUrl() + GET_EXAMS_BY_DEPARTMENT + departmentId, {headers: this.config.getHeaders()});
  }
}
