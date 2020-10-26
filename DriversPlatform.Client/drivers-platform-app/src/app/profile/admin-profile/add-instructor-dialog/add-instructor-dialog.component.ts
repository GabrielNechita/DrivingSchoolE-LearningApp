import { Component, OnInit, Inject } from '@angular/core';
import { InstructorService } from 'src/app/services/instructor.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ICategory } from 'src/app/interfaces/category.interface';
import { IInstructor } from 'src/app/interfaces/instructor.interface';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-instructor-dialog',
  templateUrl: './add-instructor-dialog.component.html',
  styleUrls: ['./add-instructor-dialog.component.css']
})
export class AddInstructorDialogComponent implements OnInit {

  addForm: FormGroup;
  selectedGender = 'male';
  hidePass: boolean = true;
  hidePassConf: boolean = true;
  categoryList: ICategory[] = [];

  constructor(public dialogRef: MatDialogRef<AddInstructorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _router: Router,
    private _instructorService: InstructorService,
    public fb: FormBuilder,
    private _snackBar: MatSnackBar) {
      this.addForm = this.fb.group({
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required, Validators.pattern('(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-\.]).{6,}')]),
        passwordConfirm: new FormControl('', [Validators.required, Validators.pattern('(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-\.]).{6,}')]),
        firstName: new FormControl('', [Validators.required]),
        lastName: new FormControl('', [Validators.required]),
        address: new FormControl('', [Validators.required]),
        birthDate: new FormControl('', [Validators.required]),
        phone: new FormControl('', [Validators.required, Validators.pattern('(?=07)(?=^[0-9]*$).{10}')]),
        hireDate: new FormControl('', [Validators.required]),
        salary: new FormControl('', [Validators.required]),
      });
     }

  

  onNoClick(): void {
    this.dialogRef.close();
  }
  
  addInstructor(){
    if(this.addForm.valid){
      if(this.addForm.get('password').value == this.addForm.get('passwordConfirm').value){
        var newInstructor: IInstructor = {
          hireDate: this.addForm.get('hireDate')?.value,
          salary: this.addForm.get('salary')?.value,
          categories: this.categoryList,
          user: {
            email: this.addForm.get('email').value,
            password: this.addForm.get('password').value,
            firstName: this.addForm.get('firstName').value,
            lastName: this.addForm.get('lastName').value,
            birthday: this.addForm.get('birthDate')?.value,
            gender: this.selectedGender,
            address: this.addForm.get('address')?.value,
            phoneNumber: this.addForm.get('phone')?.value,
          }
        }
        this._instructorService.addInstructor(newInstructor);
        this.dialogRef.close();
      }else{
        this._snackBar.open(`Parolele nu sunt egale`, 'X', {
          duration: 4000,
        });
      }
    }
  }

  ngOnInit(): void {
  }

}
