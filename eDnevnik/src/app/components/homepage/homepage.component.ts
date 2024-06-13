import { Component, EventEmitter, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RegisterComponent } from '../register/register.component';
import { VerificationComponent } from '../verification/verification.component';
import { AuthenticationComponent } from '../authentication/authentication.component';
import { ToastrService } from 'ngx-toastr';
import { openDialog } from 'src/app/shared/utilities.shared';
import { IAccountService } from 'src/app/interfaces/i-account.interface';
import { INavigationService } from 'src/app/interfaces/i-navigation.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';
import { VERIFICATION_CODE_SENT } from 'src/app/shared/messages.shared';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent {
  @Output() loggedIn = new EventEmitter<boolean>();
  loginCredentials: any = {};

  constructor(
    private accountService: IAccountService,
    private navigationService: INavigationService,
    private storageService: IStorageService,
    private toastrService: ToastrService,
    private dialog: MatDialog,
  ) { }

  register(): void {
    openDialog(this.dialog, RegisterComponent);
  }

  login(): void {
    this.accountService.login(this.loginCredentials).subscribe({
      next: response => {
        this.storageService.setLoginInfo(response.userId, response.role, response.jwtToken);
        this.storageService.setUserInfo(response.userId, response.role);
        this.navigationService.loggedIn();
      },
      error: error => {
        this.storageService.setLoginInfo(error.error.userId, error.error.role, error.error.jwtToken);
        if (error.error.statusCode == 401) {
          openDialog(this.dialog, AuthenticationComponent);
        }
        if (error.error.statusCode == 403) {
          this.toastrService.success(VERIFICATION_CODE_SENT);
          this.toastrService.info(error.error.statusMessage);
          openDialog(this.dialog, VerificationComponent);
          // TODO: Send verification mail -> napraviti metodu za ovo u Account servisu.
        }
        if (error.error.statusCode == 404) {
          this.toastrService.error(error.error.statusMessage);
        }
      }
    });
  }

}
