import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private _userService: UserService, private _router: Router, private _snackBar: MatSnackBar) { }

  email: FormControl = new FormControl('', [Validators.required, Validators.email]);
  password: FormControl = new FormControl('', [Validators.required, Validators.pattern('(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-\.]).{6,}')]);
  hidePass: boolean = true;

  formIsValid(): boolean{
    this.email.markAsTouched();
    this.password.markAsTouched();
    if (this.email.errors != null ||
      this.password.errors != null){
        this._snackBar.open('Campuri invalide!', 'X', {
          duration: 4000,
        });
        return false;
    }
    return true;
  }

  login(){
    if(this.formIsValid())
    {
      let creds = {
        email: this.email.value,
        password: this.password.value
      }
  
      this._userService.login(creds)
        .subscribe({
          next: data => {
            this._router.navigate(["/profile"]);
            this._snackBar.open('Success!', 'X', {
              duration: 4000,
            });      
          },
          error: error => {
            this._snackBar.open(`Error: ${error.error}`, 'X', {
              duration: 4000,
            });
          }
          
        });
    }   
  }
  ngOnInit() {
    
  }

}
