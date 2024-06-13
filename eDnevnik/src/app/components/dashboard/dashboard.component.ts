import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { INavigationService } from 'src/app/interfaces/i-navigation.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  @Output() loggedIn = new EventEmitter<boolean>();
  userInfo: any | undefined;
  
  gradesRoles: string[] = ['Student', 'Parent'];
  examsRoles: string[] = ['Student', 'Parent'];
  absencesRoles: string[] = ['Student', 'Parent'];
  notesRoles: string[] = ['Student', 'Parent'];
  studentRulesRoles: string[] = ['Student', 'Parent'];

  constructor(
    private navigationService: INavigationService, 
    private storageService: IStorageService,
    private router: Router
  ) { 
    this.userInfo = this.storageService.getUserInfo();
  }

  logOut(): void {
    this.storageService.removeUserInfo();
    this.storageService.removeLoginInfo();
    this.navigationService.loggedOut();
  }

  openComponent(route: string): void {
    this.router.navigate([`/${route}`]);
  }
}
