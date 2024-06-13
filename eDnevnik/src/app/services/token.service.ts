import { Injectable } from '@angular/core';
import { ITokenService } from '../interfaces/i-token.interface';

@Injectable({
  providedIn: 'root'
})
export class TokenService implements ITokenService {
 
  getLoginToken(): string {
    const loginInfo = localStorage.getItem('loginInfo');
    return loginInfo ? JSON.parse(loginInfo).jwtToken : null;
  }
}
