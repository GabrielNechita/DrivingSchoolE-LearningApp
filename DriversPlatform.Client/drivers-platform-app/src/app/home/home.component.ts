import { Component, OnInit, AfterViewInit } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  animations: [
    trigger('textState', [
      state('normal', style({
        transform: 'translateY(-100px)'
      })),
      state('center', style({
        transform: 'translateY(250px)'
      })),
      transition('normal => center', animate(1000))
    ])
  ]
})
export class HomeComponent implements AfterViewInit {
  state: string = 'normal';

  constructor() { 
  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.state = 'center';
    }, 0);
    
  }

}
