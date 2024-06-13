import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { INoteService } from 'src/app/interfaces/i-note.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';
import { Note } from 'src/app/models/response/notes.response.model';
import { Student } from 'src/app/models/response/student.response.model';
import { fadeInOut } from 'src/app/shared/animations.shared';
import { ERROR, NO_NOTES } from 'src/app/shared/messages.shared';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss'],
  animations: [fadeInOut]
})
export class NotesComponent implements OnInit, OnDestroy {
  userInfo: any | undefined;
  students: Student[] = [];
  selectedStudent: any = {};
  studentNotes: Note[] = [];

  constructor(
    private noteService: INoteService,
    private storageService: IStorageService,
    private toastrService: ToastrService
  ) {
    this.userInfo = this.storageService.getUserInfo();
  }

  ngOnInit(): void {
    this.componentSetUp();
  }

  ngOnDestroy(): void {
    this.toastrService.clear();
  }

  private componentSetUp(): void {
    if (this.userInfo?.role === 'Student') {
      this.getNotesByStudent(this.userInfo?.id);
    }
    if (this.userInfo?.role === 'Parent') {
      this.students = this.userInfo?.students;
    }
  }

  private getNotesByStudent(studentId: number): void {
    this.noteService.getNotesByStudent(studentId).subscribe({
      next: response => this.studentNotes = response,
      error: error => {
        if (error.status === 404) {
          this.toastrService.info(NO_NOTES);
        } else {
          this.toastrService.error(ERROR);
          console.error(error);
        }
        this.studentNotes = [];
      }
    });
  }

  loadStudentsNotes(): void {
    this.toastrService.clear();
    if (this.selectedStudent != '-') {
      let student = this.students.find((s: any) => s.id == this.selectedStudent);
      if (student != null) {
        this.getNotesByStudent(student.id);
      }
    } else {
      this.studentNotes = [];
    }
  }
}
