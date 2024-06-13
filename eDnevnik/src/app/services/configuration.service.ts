import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { IConfigurationService } from '../interfaces/i-configuration.interface';
import { ITokenService } from '../interfaces/i-token.interface';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService implements IConfigurationService {

  constructor(private tokenService: ITokenService) {
  }

  getBaseUrl(): string {
    return environment.apiUrl;
  }

  getHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', environment.headers.accept);
    headers = headers.set('Authorization', 'Bearer ' + this.tokenService.getLoginToken());
    return headers;
  }
  
}
