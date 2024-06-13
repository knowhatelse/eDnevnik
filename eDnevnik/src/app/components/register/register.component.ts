import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { VerificationComponent } from '../verification/verification.component';
import { openDialog } from 'src/app/shared/utilities.shared';
import { IAccountService } from 'src/app/interfaces/i-account.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerCredentials: any = {};

  constructor(
    private accountService: IAccountService,
    private storageService: IStorageService,
    private toastrService: ToastrService,
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<RegisterComponent>
  ) { }

  register(): void {
    this.accountService.register(this.registerCredentials).subscribe({
      next: response => {
        this.storageService.setLoginInfo(response.userId, response.role, response.jwtToken);
        this.storageService.setUserInfo(response.userId, response.role);
        this.dialogRef.close();
        openDialog(this.dialog, VerificationComponent);
      },
      error: error => {
        this.toastrService.error(error.error.statusMessage);
      }
    });
  }

}
