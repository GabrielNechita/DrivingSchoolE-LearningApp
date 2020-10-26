import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private _snackBar: MatSnackBar, private _userService: UserService) { }

  email: FormControl = new FormControl('', [Validators.required, Validators.email]);
  password: FormControl = new FormControl('', [Validators.required, Validators.pattern('(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-\.]).{6,}')]);
  passwordConfirm: FormControl = new FormControl('', [Validators.required, Validators.pattern('(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-\.]).{6,}')]);
  firstName: FormControl = new FormControl('', [Validators.required]);
  lastName: FormControl = new FormControl('', [Validators.required]);
  address: FormControl = new FormControl('', [Validators.required]);
  birthDate: FormControl = new FormControl('', [Validators.required]);
  phone: FormControl = new FormControl('', [Validators.required, Validators.pattern('(?=07)(?=^[0-9]*$).{10}')]);

  selectedGender = 'male';
  hidePass: boolean = true;
  hidePassConf: boolean = true;

  currentDate = new Date();

  openSnackBar(message: string) {
    this._snackBar.open(message, 'X', {
      duration: 4000,
    });
  }

  formIsValid(): boolean{
    if (this.password.value != this.passwordConfirm.value) {
      this.openSnackBar('Parolele nu sunt egale!');
      return false;
    }

    if (this.email.errors != null ||
          this.password.errors != null ||
          this.passwordConfirm.errors != null ||
          this.firstName.errors != null ||
          this.lastName.errors != null ||
          this.address.errors != null ||
          this.birthDate.errors != null ||
          this.phone.errors != null){

      this.openSnackBar('Campuri obligatorii necompletate sau invalide!');
      return false;
    }

    return true;
  }

  signup(){
    if(this.formIsValid()){
      let newUser = {
        email: this.email.value,
        password: this.password.value,
        firstName: this.firstName.value,
        lastName: this.lastName.value,
        address: this.address.value,
        birthday: this.birthDate.value,
        phoneNumber: this.phone.value,
        gender: this.selectedGender
      }
      this._userService.signup(newUser);
    }
    
  }
  ngOnInit() {
   var urrentDate = new Date();
   console.log(urrentDate)
  }

}
