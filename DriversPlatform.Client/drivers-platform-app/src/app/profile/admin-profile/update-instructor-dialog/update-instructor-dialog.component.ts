import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ICategory } from 'src/app/interfaces/category.interface';
import { AddInstructorDialogComponent } from '../add-instructor-dialog/add-instructor-dialog.component';
import { Router } from '@angular/router';
import { InstructorService } from 'src/app/services/instructor.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-update-instructor-dialog',
  templateUrl: './update-instructor-dialog.component.html',
  styleUrls: ['./update-instructor-dialog.component.css']
})
export class UpdateInstructorDialogComponent implements OnInit {

  categoryList: ICategory[] = [];
  isAdmin: boolean;

  constructor(public dialogRef: MatDialogRef<UpdateInstructorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _router: Router,
    private _instructorService: InstructorService,
    private _snackBar: MatSnackBar) {
    } 

  onNoClick(): void {
    this.dialogRef.close();
  }

  updateInstructor(){
    this.data.instructor.categories = this.categoryList;
    console.log(this.data.instructor.user.birthday);
    this._instructorService.updateInstructor(this.data.instructor);
    this.dialogRef.close();
  }

  compareCat(category){
    if (this.data.instructor.categories.find(cat => cat.name == category.name)) {
      return true;
    }
    return false;
  }

  ngOnInit(): void {
    if (localStorage.getItem('userRole') == "admin") {
      this.isAdmin = true;
    }
    else{
      this.isAdmin = false;
    }
  }

}
