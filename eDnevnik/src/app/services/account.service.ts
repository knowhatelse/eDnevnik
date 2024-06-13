import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { Account } from '../models/response/account.response.model';
import { Code } from '../models/request/code.request.model';
import { Observable } from 'rxjs';
import { Login } from '../models/request/login.request.model';
import { Register } from '../models/request/register.request.model';
import { LOGIN_AUTHENTICATION_URL, LOGIN_AUTH_CODE_URL, LOGIN_URL, REGISTER_URL, REGISTER_VERIFICATION_CODE_URL, REGISTER_VERIFICATION_URL } from '../shared/api-url.shared';
import { IAccountService } from '../interfaces/i-account.interface';
import { IStorageService } from '../interfaces/i-storage.interface';
import { IConfigurationService } from '../interfaces/i-configuration.interface';

@Injectable({
  providedIn: 'root'
})
export class AccountService implements IAccountService {

  constructor(
    private httpClient: HttpClient,
    private config: IConfigurationService,
    private storageService: IStorageService
  ) { }

  login(request: Login): Observable<Account> {
    return this.httpClient.post<Account>(this.config.getBaseUrl() + LOGIN_URL, request);
  }

  loginAuthentication(authenticationCode: string): Observable<Account> {
    const loginInfo = this.storageService.getLoginInfo();
    const authenticationRequest: Code = {
      userId: loginInfo.id,
      code: authenticationCode
    };
    return this.httpClient.post<Account>(this.config.getBaseUrl() + LOGIN_AUTHENTICATION_URL, authenticationRequest);
  }

  sendLoginAuthenticationCode(): Observable<Account> {
    const loginInfo = this.storageService.getLoginInfo();
    return this.httpClient.post<Account>(this.config.getBaseUrl() + LOGIN_AUTH_CODE_URL + loginInfo.id, {});
  }

  register(request: Register): Observable<Account> {
    return this.httpClient.post<Account>(this.config.getBaseUrl() + REGISTER_URL, request);
  }

  registerVerification(verificationCode: string): Observable<Account> {
    const loginInfo = this.storageService.getLoginInfo();
    const verificationRequest: Code = {
      userId: loginInfo.id,
      code: verificationCode
    };
    return this.httpClient.post<Account>(this.config.getBaseUrl() + REGISTER_VERIFICATION_URL, verificationRequest);
  }

  sendRegisterVerificationCode(): Observable<Account> {
    const loginInfo = this.storageService.getLoginInfo();
    return this.httpClient.post<Account>(this.config.getBaseUrl() + REGISTER_VERIFICATION_CODE_URL + loginInfo.id, {});
  }

}
