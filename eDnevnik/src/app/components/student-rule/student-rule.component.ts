import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';
import { IStudentRuleService } from 'src/app/interfaces/i-student-rule.interface';
import { StudentRule } from 'src/app/models/response/student-rule.response.model';
import { Student } from 'src/app/models/response/student.response.model';
import { fadeInOut } from 'src/app/shared/animations.shared';
import { ERROR, NO_STUDENT_RULE } from 'src/app/shared/messages.shared';

@Component({
  selector: 'app-student-rule',
  templateUrl: './student-rule.component.html',
  styleUrls: ['./student-rule.component.scss'],
  animations: [fadeInOut]
})
export class StudentRuleComponent implements OnInit, OnDestroy {
  userInfo: any = {};
  students: Student[] = [];
  studentRules: StudentRule[] = [];
  selectedStudent: any = '-';

  constructor(
    private studentRuleService: IStudentRuleService, 
    private storageService: IStorageService,
    private toastrService: ToastrService
  ) {
    this.userInfo = this.storageService.getUserInfo();
  }

  ngOnInit(): void {
    this.componentSetUp();
  }

  ngOnDestroy(): void {
    this.toastrService.clear()
  }

  private componentSetUp(): void {
    if (this.userInfo?.role === 'Student') {
      this.getStudentRulesByStudent(this.userInfo?.id);
    }
    if (this.userInfo?.role === 'Parent') {
      this.students = this.userInfo?.students;
    }
  }

  getStudentRulesByStudent(studentId: number): void {
    this.studentRuleService.getStudentRuleByStudent(studentId).subscribe({
      next: response => this.studentRules = response,
      error: error => {
        if (error.status === 404) {
          this.toastrService.info(NO_STUDENT_RULE);
        } else {
          this.toastrService.error(ERROR);
          console.error(error);
        }
        this.studentRules = [];
      }
    });
  }

  loadStudentRules(): void {
    this.toastrService.clear();
    if (this.selectedStudent != '-') {
      let student = this.students.find((s: any) => s.id == this.selectedStudent);
      if (student != null) {
        this.getStudentRulesByStudent(student.id);
      }
    } else {
      this.studentRules = [];
    }
  }
}
