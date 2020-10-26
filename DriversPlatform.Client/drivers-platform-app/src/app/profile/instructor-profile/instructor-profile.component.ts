import { Component, OnInit } from '@angular/core';
import { InstructorService } from 'src/app/services/instructor.service';
import { IInstructor } from 'src/app/interfaces/instructor.interface';
import { CategoryService } from 'src/app/services/category.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UpdateInstructorDialogComponent } from '../admin-profile/update-instructor-dialog/update-instructor-dialog.component';
import { ICategory } from 'src/app/interfaces/category.interface';

@Component({
  selector: 'app-instructor-profile',
  templateUrl: './instructor-profile.component.html',
  styleUrls: ['./instructor-profile.component.css']
})
export class InstructorProfileComponent implements OnInit {

  constructor(
    private _categoryService: CategoryService,
     public dialog: MatDialog,
      private _router: Router,
       private _instructorService: InstructorService
  ) { }

  pictureUrl;
  defaultUrl = "../../../assets/blank-profile-picture.png";
  instructor: IInstructor;
  viewClients: boolean = false;
  categories: ICategory[];
  
  updateInstructor(){
    const dialogRef = this.dialog.open(UpdateInstructorDialogComponent, {
      width: '400px',
      data: { instructor: this.instructor, categories: this.categories}
    });

    dialogRef.afterClosed().subscribe(result => {

      window.location.reload();
    });
  }

  giveQuizAccess(clientId: number){
    this._instructorService.giveQuizAccess(clientId);
    window.location.reload();
  }

  ngOnInit() {
    this._instructorService.getInstructorByEmail()
      .subscribe((data:IInstructor) => {
        this.instructor = data;
        console.log(this.instructor);
     });
    this._categoryService.getCategories()
     .subscribe((data:ICategory[]) => {
       this.categories = data.sort((a, b) => a.name?.localeCompare(b.name));
    });
  }

}
