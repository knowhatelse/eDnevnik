import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IGradeService } from 'src/app/interfaces/i-grade.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';
import { ISubjectService } from 'src/app/interfaces/i-subject.interface';
import { Grade } from 'src/app/models/response/grades.response.model';
import { Student } from 'src/app/models/response/student.response.model';
import { Subject } from 'src/app/models/response/subject.response.model';
import { fadeInOut } from 'src/app/shared/animations.shared';
import { ERROR, ERROR_SUBJECTS, NO_GRADES } from 'src/app/shared/messages.shared';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.scss'],
  animations: [fadeInOut]
})
export class GradesComponent implements OnInit, OnDestroy {
  userInfo: any | undefined;
  students: Student[] = [];
  selectedStudent: string = '-';
  studentGrades: Grade[] = [];
  gradeValues: number[] = [];
  selectedGrade: string = '-';
  subjects: Subject[] = [];
  selectedSubject: string = '-';

  constructor(
    private gradeService: IGradeService,
    private subjectService: ISubjectService,
    private storageService: IStorageService,
    private toastrService: ToastrService
  ) {
    this.userInfo = this.storageService.getUserInfo();
    this.gradeValues = [1, 2, 3, 4, 5];
  }

  ngOnInit(): void {
    this.componentSetUp();
    this.getSubjects(this.userInfo?.schoolId);
  }

  ngOnDestroy(): void {
    this.toastrService.clear()
  }

  private componentSetUp(): void {
    if (this.userInfo?.role === "Student") {
      this.getGrades(this.userInfo?.id);
    }
    if (this.userInfo?.role === "Parent") {
      this.students = this.userInfo?.students;
    }
  }

  private getGrades(studentId: number): void {
    this.gradeService.getStudentGrades(studentId).subscribe({
      next: response => this.studentGrades = response,
      error: error => {
        if (error.status === 404) {
          this.toastrService.info(NO_GRADES);
        } else {
          this.toastrService.error(ERROR);
          console.error(error);
        }
        this.studentGrades = [];
      }
    });
  }

  private getSubjects(schoolId: number): void {
    this.subjectService.getAllSubjects(schoolId).subscribe({
      next: response => this.subjects = response,
      error: error => {
        if (error.status === 404) {
          this.toastrService.error(ERROR_SUBJECTS);
        } else {
          this.toastrService.error(ERROR);
          console.error(error);
        }
      }
    });
  }

  loadStudentGrades(): void {
    this.toastrService.clear();
    if (this.selectedStudent != '-') {
      this.getGrades(parseInt(this.selectedStudent));
    } else {
      this.studentGrades = [];
    }
  }

  filterGrades(): Grade[] {
    return this.studentGrades.filter((sg: any) => (
      (this.selectedGrade == '-') || (sg.gradeValue == this.selectedGrade)
    ) && (
        (this.selectedSubject == '-') || (sg.subjectId == this.selectedSubject)
      ));
  }

}
