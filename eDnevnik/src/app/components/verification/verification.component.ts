import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef } from '@angular/material/dialog';
import { IAccountService } from 'src/app/interfaces/i-account.interface';
import { INavigationService } from 'src/app/interfaces/i-navigation.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';

@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.scss']
})
export class VerificationComponent {
  verificationToken: string | undefined;

  constructor (
    private accountService: IAccountService,
    private navigationService: INavigationService,
    private storageService: IStorageService,
    private toastrService: ToastrService,
    private dialogRef: MatDialogRef<VerificationComponent>
  ) {
    this.resendVerificationCode();
  }

  verificate(): void {
    if (this.verificationToken) {
      this.accountService.registerVerification(this.verificationToken).subscribe({
        next: response => {
          this.storageService.setLoginInfo(response.userId, response.role, response.jwtToken);
          this.storageService.setUserInfo(response.userId, response.role);
          this.dialogRef.close();
          this.navigationService.loggedIn();
        },
        error: error => {
          this.toastrService.error(error.error.statusMessage);
        }
      });
    }
  }

  resendVerificationCode(): void {
    this.accountService.sendRegisterVerificationCode().subscribe({
      next: response => {
        this.toastrService.success(response.statusMessage);
      },
      error: error => {
        this.toastrService.error(error.error.statusMessage);
      }
    });
  }

}
