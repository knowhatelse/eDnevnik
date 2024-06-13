import { Component, OnInit } from '@angular/core';
import { trigger, state, style, animate, transition, keyframes } from '@angular/animations';
import { INavigationService } from './interfaces/i-navigation.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [
    trigger('fadeInOut', [
      state('void', style({
        opacity: 0
      })),
      transition(':enter, :leave', [
        animate(500)
      ])
    ])
  ]
})
export class AppComponent implements OnInit {
  title = 'eDnevnik';
  isLoggedIn = false;

  constructor(private navigation: INavigationService) {
  }

  ngOnInit(): void {
    this.navigation.isLoggedIn$.subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn;
    });
    const isLoggedIn = localStorage.getItem('isLoggedIn');
    if (isLoggedIn !== null) {
      this.isLoggedIn = JSON.parse(isLoggedIn);
    }
  }

}
