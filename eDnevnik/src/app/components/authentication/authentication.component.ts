import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef } from '@angular/material/dialog';
import { IAccountService } from 'src/app/interfaces/i-account.interface';
import { INavigationService } from 'src/app/interfaces/i-navigation.interface';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss']
})
export class AuthenticationComponent {
  authenticationCode: string | undefined;

  constructor(
    private accountService: IAccountService,
    private navigationService: INavigationService,
    private toastrService: ToastrService,
    private dialogRef: MatDialogRef<AuthenticationComponent>
  ) {
    this.accountService.sendLoginAuthenticationCode();
  }

  authenticate(): void {
    if (this.authenticationCode) {
      this.accountService.loginAuthentication(this.authenticationCode).subscribe({
        next: () => {
          this.dialogRef.close();
          this.navigationService.loggedIn();
        },
        error: error => {
          this.toastrService.error(error.error.statusMessage);
        }

      });
    }
  }

  resendAuthenticationCode(): void {
    this.accountService.sendLoginAuthenticationCode().subscribe({
      next: response => {
        this.toastrService.success(response.statusMessage);
      },
      error: error => {
        this.toastrService.error(error.error.statusMessage);
      }
    });
  }

}
