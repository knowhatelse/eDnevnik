import { BehaviorSubject } from "rxjs";

export abstract class INavigationService {
    isLoggedInSubject = new BehaviorSubject<boolean>(false);
    isLoggedIn$ = this.isLoggedInSubject.asObservable();

    abstract setLoginStatus(): void;
    abstract getLoginStatus(): boolean;
    abstract loggedIn(): void;
    abstract loggedOut(): void;
}