import { Component, OnInit } from '@angular/core';
import { DriverService } from 'src/app/services/driver.service';
import { IDriver } from 'src/app/interfaces/driver.interface';
import { MatDialog } from '@angular/material/dialog';
import { UpdateDialogComponent } from './update-dialog/update-dialog.component';
import { Router } from '@angular/router';
import { InstructorService } from 'src/app/services/instructor.service';
import { IInstructor } from 'src/app/interfaces/instructor.interface';
import { ICategory } from 'src/app/interfaces/category.interface';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-driver-profile',
  templateUrl: './driver-profile.component.html',
  styleUrls: ['./driver-profile.component.css']
})
export class DriverProfileComponent implements OnInit {

  constructor(private _driverService: DriverService,
    private _categoryService: CategoryService,
     public dialog: MatDialog,
      private _router: Router,
       private _instructorService: InstructorService
       ) {}
  pictureUrl;
  defaultUrl = "../../../assets/blank-profile-picture.png";
  driver: IDriver;
  instructors: IInstructor[];
  categoryName: string;
  pickInstructor: boolean;
  selectedInstructor: IInstructor;
  buttonMessage: string = "";
  categories: ICategory[];
  displayedColumns: string[] = ['difficulty', 'category', 'score'];

  openDialog(){

    const dialogRef = this.dialog.open(UpdateDialogComponent, {
      width: '400px',
      data: {driver: this.driver}
    });

    dialogRef.afterClosed().subscribe(result => {

      window.location.reload();
    });

  }

  getInstructors(){
    this._instructorService.getInstructorsByCategory(this.categoryName)
      .subscribe((data: IInstructor[]) => {
        this.instructors = data;
        console.log(this.instructors);
      });
  }

  assignInstructor(){
    this.pickInstructor = false;

    this._driverService.addCategoryToDriver(this.driver.id, this.categoryName);
    this._driverService.addInstructorToDriver(this.driver.id, this.selectedInstructor.id);
     
    window.location.reload();
  }

  openInstructorForm(){
    this.pickInstructor = !this.pickInstructor;
  }

  ngOnInit() {
    
    this.pickInstructor = false;

    this._driverService.getDriverByEmail()
      .subscribe((data:IDriver) => {
        this.driver = data;

        if (this.driver?.instructor == null) {
          this.buttonMessage = "Alege instructor";
        }
        else{
          this.buttonMessage = "Schimba instructor";
        }
      });

      this._categoryService.getCategories()
      .subscribe((data:ICategory[]) => {
        this.categories = data;
      });
  }

}
