import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IAbsenceService } from 'src/app/interfaces/i-absence.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';
import { ISubjectService } from 'src/app/interfaces/i-subject.interface';
import { Absence } from 'src/app/models/response/absence.response.model';
import { Student } from 'src/app/models/response/student.response.model';
import { Subject } from 'src/app/models/response/subject.response.model';
import { fadeInOut } from 'src/app/shared/animations.shared';
import { ERROR, ERROR_SUBJECTS, NO_ABSENCES } from 'src/app/shared/messages.shared';

@Component({
  selector: 'app-absence',
  templateUrl: './absence.component.html',
  styleUrls: ['./absence.component.scss'],
  animations: [fadeInOut]
})
export class AbsenceComponent implements OnInit, OnDestroy {
  userInfo: any | undefined;
  students: Student[] = [];
  selectedStudent: string = '-';
  studentAbsences: Absence[] = [];
  subjects: Subject[] = [];
  selectedSubject: string = '-';
  justificationTypes: boolean[] = [];
  selectedJustification: string = '-';

  constructor(
    private absenceService: IAbsenceService,
    private subjectService: ISubjectService,
    private storageService: IStorageService,
    private toastrService: ToastrService
  ) {
    this.userInfo = this.storageService.getUserInfo();
    this.justificationTypes = [true, false]
  }

  ngOnInit(): void {
    this.componentSetUp();
    this.getSubjects(this.userInfo?.schoolId);
  }

  ngOnDestroy(): void {
    this.toastrService.clear()
  }

  private componentSetUp(): void {
    if (this.userInfo?.role === 'Student') {
      this.getStudentAbsences(this.userInfo?.id);
    }
    if (this.userInfo?.role === 'Parent') {
      this.students = this.userInfo?.students;
    }
  }

  private getStudentAbsences(studentId: number): void {
    this.absenceService.getAbsencesByStudent(studentId).subscribe({
      next: response => this.studentAbsences = response,
      error: error => {
        if (error.status === 404) {
          this.toastrService.info(NO_ABSENCES);
        } else {
          this.toastrService.error(ERROR);
          console.error(error);
        }
        this.studentAbsences = [];
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

  filterAbsences(): Absence[] {
    return this.studentAbsences.filter((sa: any) => (
      (this.selectedJustification == '-') || (sa.justified === this.selectedJustification)
    ) && (
        (this.selectedSubject == '-') || (sa.lecture == this.selectedSubject)
      )
    );
  }

  loadStudentAbsences(): void {
    this.toastrService.clear();
    if (this.selectedStudent != '-') {
      let student = this.students.find((s: any) => s.id == this.selectedStudent);
      if (student != null) {
        this.getStudentAbsences(student.id);
      }
    } else {
      this.studentAbsences = [];
    }
  }

}
