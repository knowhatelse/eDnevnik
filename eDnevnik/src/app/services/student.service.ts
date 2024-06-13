import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from '../models/response/student.response.model';
import { Observable } from 'rxjs';
import { GET_STUDENT_BY_ID } from '../shared/api-url.shared';
import { IStudentService } from '../interfaces/i-student.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class StudentService implements IStudentService {

  constructor(private httpClient: HttpClient, private config: IConfigurationService) { }

  getStudentById(id: number): Observable<Student> {
    return this.httpClient.get<Student>(this.config.getBaseUrl() + GET_STUDENT_BY_ID + id, { headers: this.config.getHeaders() });
  }
}
