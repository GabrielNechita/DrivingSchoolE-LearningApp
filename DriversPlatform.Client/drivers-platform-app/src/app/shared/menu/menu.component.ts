import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private _router: Router) { }
  opened:boolean = false;
  isDriver: boolean;

  toggleSideBar() {
    this.opened = !this.opened;
  }

  logout(){
    localStorage.clear();
 
    this._router.routeReuseStrategy.shouldReuseRoute = () => false;
    this._router.onSameUrlNavigation = 'reload';
    this._router.navigate(['/']);
    
  }

  isLoggedin(): boolean{
    if(localStorage.token != null){
      return true;
    }
    return false;
  }
  
  ngOnInit() {
    if(localStorage.getItem('userRole') == 'driver')
      this.isDriver = true;
  }

}
