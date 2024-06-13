import { Observable } from "rxjs";
import { Login } from "../models/request/login.request.model";
import { Account } from "../models/response/account.response.model";
import { Register } from "../models/request/register.request.model";

export abstract class IAccountService {
    abstract login(request: Login): Observable<Account>;
    abstract loginAuthentication(authenticationCode: string): Observable<Account>;
    abstract loginAuthentication(authenticationCode: string): Observable<Account>;
    abstract sendLoginAuthenticationCode(): Observable<Account>;
    abstract sendLoginAuthenticationCode(): Observable<Account>;
    abstract register(request: Register): Observable<Account>;
    abstract registerVerification(verificationCode: string): Observable<Account>;
    abstract sendRegisterVerificationCode(): Observable<Account>;
}