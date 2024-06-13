import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StudentRule } from '../models/response/student-rule.response.model';
import { Observable } from 'rxjs';
import { GET_STUDENT_RULE_BY_STUDENT } from '../shared/api-url.shared';
import { IStudentRuleService } from '../interfaces/i-student-rule.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class StudentRuleService implements IStudentRuleService {

  constructor(private httpClient: HttpClient, private config: IConfigurationService) { }

  getStudentRuleByStudent(studentId: number): Observable<StudentRule[]> {
    return this.httpClient.get<StudentRule[]>(this.config.getBaseUrl() + GET_STUDENT_RULE_BY_STUDENT + studentId, {headers: this.config.getHeaders()});
  }
}
