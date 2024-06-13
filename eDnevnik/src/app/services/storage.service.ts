import { Injectable } from '@angular/core';
import { IStorageService } from '../interfaces/i-storage.interface';
import { IStudentService } from '../interfaces/i-student.interface';
import { IParentService } from '../interfaces/i-parent.interface';

@Injectable({
  providedIn: 'root'
})
export class StorageService implements IStorageService{

  constructor(
    private studentService: IStudentService,
    private parentService: IParentService,
  ) { }

  setLoginInfo(userId: number, role: string, token: string): void {
    localStorage.setItem('loginInfo', JSON.stringify({
      id: userId,
      role: role,
      jwtToken: token
    }));
  }

  setUserInfo(userId: any, role: string): void {
    if (role === "Student") {
      this.studentService.getStudentById(userId).subscribe({
        next: response => {
          localStorage.setItem('userInfo', JSON.stringify(response));
        },
        error: error => console.error(error)
      });
    }
    if (role === "Parent") {
      this.parentService.getParentById(userId).subscribe({
        next: response => localStorage.setItem('userInfo', JSON.stringify(response)),
        error: error => console.error(error)
      });
    }
  }

  getLoginInfo(): any {
    const storedData = localStorage.getItem('loginInfo');
    if (storedData !== null) {
      return JSON.parse(storedData);
    }
  }

  getUserInfo(): any {
    const storedData = localStorage.getItem('userInfo');
    if (storedData !== null) {
      return JSON.parse(storedData);
    }
  }

  removeLoginInfo(): void {
    localStorage.removeItem('loginInfo');
  }

  removeUserInfo(): void {
    localStorage.removeItem('userInfo');
  }
}
