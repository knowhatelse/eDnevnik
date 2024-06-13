import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Grade } from '../models/response/grades.response.model';
import { Observable } from 'rxjs';
import { GET_STUDENT_GRADES } from '../shared/api-url.shared';
import { IGradeService } from '../interfaces/i-grade.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class GradeService implements IGradeService {

  constructor(private httpClient: HttpClient, private config: IConfigurationService) { }

  getStudentGrades(studentId: number): Observable<Grade[]> {
    return this.httpClient.get<Grade[]>(this.config.getBaseUrl() + GET_STUDENT_GRADES + studentId, {headers: this.config.getHeaders()});
  }
}
