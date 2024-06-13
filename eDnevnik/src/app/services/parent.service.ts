import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parent } from '../models/response/parent.response.model';
import { Observable } from 'rxjs';
import { GET_PARENT_BY_ID } from '../shared/api-url.shared';
import { IParentService } from '../interfaces/i-parent.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class ParentService implements IParentService {

  constructor(private httpClient: HttpClient, private config: IConfigurationService) { }

  getParentById(parentId: number): Observable<Parent> {
    return this.httpClient.get<Parent>(this.config.getBaseUrl() + GET_PARENT_BY_ID + parentId, {headers: this.config.getHeaders()});
  }
}
