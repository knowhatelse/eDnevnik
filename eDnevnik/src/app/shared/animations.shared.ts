import { trigger, state, style, transition, animate } from '@angular/animations';

export const fadeInOut = trigger('fadeInOut', [
  state('void', style({
    transform: 'scale(0.5)',
    opacity: 0
  })),
  transition('void <=> *', animate('500ms ease-in-out')),
]);
