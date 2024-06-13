import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { INavigationService } from 'src/app/interfaces/i-navigation.interface';
import { IStorageService } from 'src/app/interfaces/i-storage.interface';

@Component({
  selector: 'app-redirection',
  templateUrl: './redirection.component.html',
  styleUrls: ['./redirection.component.scss']
})
export class RedirectionComponent implements OnInit {

  constructor(private navigationService: INavigationService, private router: Router) {}

  ngOnInit(): void {
    this.redirect();
  }

  redirect() {
    if(this.navigationService.getLoginStatus()) {
      this.router.navigate(['/information']);
    } else {
      this.router.navigate(['']);
    }
  }

}
