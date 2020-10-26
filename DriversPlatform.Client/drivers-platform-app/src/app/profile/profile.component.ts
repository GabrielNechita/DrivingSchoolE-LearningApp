import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor() { }
  
  isGoodRole(role: string): boolean{
    if (localStorage.getItem('userRole') != null && localStorage.getItem('userRole') == role) {
      return true;
    }
    return false;
  }

  ngOnInit() {
  }

}
