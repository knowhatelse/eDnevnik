import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { INavigationService } from '../interfaces/i-navigation.interface';

@Injectable({
  providedIn: 'root'
})
export class NavigationService implements INavigationService {
  isLoggedInSubject = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this.isLoggedInSubject.asObservable();

  constructor(private router: Router) { 
    this.setLoginStatus();
  }
   
  setLoginStatus(): void {
    const isLoggedIn = localStorage.getItem('isLoggedIn');
    if (isLoggedIn !== null) {
      this.isLoggedInSubject.next(JSON.parse(isLoggedIn));
    }
  }

  getLoginStatus(): boolean{
    const isLoggedIn = localStorage.getItem('isLoggedIn');
    if (isLoggedIn !== null) {
      return JSON.parse(isLoggedIn);
    }
    return false;
  }

  loggedIn(): void {
    setTimeout(() => {
      this.isLoggedInSubject.next(true);
      localStorage.setItem('isLoggedIn', 'true');
      this.router.navigate([`/information`])
    }, 500);
  }

  loggedOut(): void {
    this.isLoggedInSubject.next(false);
    localStorage.setItem('isLoggedIn', 'false');
    this.router.navigate([``])
  }
}
