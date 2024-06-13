import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IExamService } from 'src/app/interfaces/i-exam.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';
import { ISubjectService } from 'src/app/interfaces/i-subject.interface';
import { Exams } from 'src/app/models/response/exams.response.model';
import { Student } from 'src/app/models/response/student.response.model';
import { Subject } from 'src/app/models/response/subject.response.model';
import { fadeInOut } from 'src/app/shared/animations.shared';
import { ERROR, ERROR_SUBJECTS, NO_EXAMS } from 'src/app/shared/messages.shared';

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.scss'],
  animations: [fadeInOut]
})
export class ExamsComponent implements OnInit, OnDestroy {
  userInfo: any | undefined;
  students: Student[] = [];
  selectedStudent: string = '-';
  studentExams: Exams[] = [];
  subjects: Subject[] = [];
  selectedSubject: string = '-';

  constructor(
    private examService: IExamService,
    private storageService: IStorageService,
    private subjectService: ISubjectService,
    private toastrService: ToastrService
  ) {
    this.userInfo = this.storageService.getUserInfo();
  }

  ngOnInit(): void {
    this.componentSetUp()
    this.getSubjects(this.userInfo?.schoolId);
  }

  ngOnDestroy(): void {
    this.toastrService.clear()
  }

  private componentSetUp(): void {
    if (this.userInfo?.role === "Student") {
      this.getStudentExams(this.userInfo?.departmentId);
    }
    if (this.userInfo?.role === "Parent") {
      this.students = this.userInfo?.students;
    }
  }

  private getStudentExams(departmentId: number): void {
    this.examService.getExamsByDepartment(departmentId).subscribe({
      next: response => this.studentExams = response,
      error: error => {
        if (error.status === 404) {
          this.toastrService.info(NO_EXAMS);
        } else {
          this.toastrService.error(ERROR);
          console.error(error);
        }
        this.studentExams = [];
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

  filterExams(): Exams[] {
    return this.studentExams.filter((sg: any) => (
      (this.selectedSubject == '-') || (sg.subjectId == this.selectedSubject)
    ));
  }

  loadStudentExams(): void {
    this.toastrService.clear();
    if (this.selectedStudent != '-') {
      let student = this.students.find((s: any) => s.id == this.selectedStudent);
      if (student != null) {
        this.getStudentExams(student.departmentId);
      };
    } else {
      this.studentExams = [];
    }
  }
}
