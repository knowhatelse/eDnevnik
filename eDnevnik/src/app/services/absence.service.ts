import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Absence } from '../models/response/absence.response.model';
import { Observable } from 'rxjs';
import { GET_ABSENCES_BY_STUDENT_URL } from '../shared/api-url.shared';
import { IAbsenceService } from '../interfaces/i-absence.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class AbsenceService implements IAbsenceService {

  constructor(private httpClient: HttpClient, private config: IConfigurationService) { }

  getAbsencesByStudent(studentId: number): Observable<Absence[]> {
    return this.httpClient.get<Absence[]>(this.config.getBaseUrl() + GET_ABSENCES_BY_STUDENT_URL + studentId, {headers: this.config.getHeaders()});
  }
}
