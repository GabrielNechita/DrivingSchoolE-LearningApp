import { Component, OnInit } from '@angular/core';
import { IDriver } from 'src/app/interfaces/driver.interface';
import { DriverService } from 'src/app/services/driver.service';
import { Router } from '@angular/router';
import { IInstructor } from 'src/app/interfaces/instructor.interface';
import { InstructorService } from 'src/app/services/instructor.service';
import { MatDialog } from '@angular/material/dialog';
import { AddInstructorDialogComponent } from './add-instructor-dialog/add-instructor-dialog.component';
import { ICategory } from 'src/app/interfaces/category.interface';
import { UpdateInstructorDialogComponent } from './update-instructor-dialog/update-instructor-dialog.component';
import { CategoryService } from 'src/app/services/category.service';
import { AddCategoryDialogComponent } from './add-category-dialog/add-category-dialog.component';
import { UpdateCategoryDialogComponent } from './update-category-dialog/update-category-dialog.component';
import { IResource } from 'src/app/interfaces/resource.interface';
import { ResourceService } from 'src/app/services/resource.service';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-profile',
  templateUrl: './admin-profile.component.html',
  styleUrls: ['./admin-profile.component.css']
})
export class AdminProfileComponent implements OnInit {

  constructor( 
    public dialog: MatDialog,
    private _driverService: DriverService,
    private _categoryService: CategoryService, 
    private _router:Router, 
    private _instructorService: InstructorService,
    private _resourceService: ResourceService) { }

  selectedDriver: IDriver;
  drivers: IDriver[];
  selectedInstructor: IInstructor;
  instructors: IInstructor[];
  categories: ICategory[];
  selectedCategory: ICategory;
  selectedResource: IResource;
  resourceFile: File;
  resourceName: FormControl;
  resources: IResource[];

  deleteDriver(){
    this._driverService.deleteDriver(this.selectedDriver.id).subscribe();

    window.location.reload();

  }

  deleteInstructor(){

    this._instructorService.deleteInstructor(this.selectedInstructor.id).subscribe();
    window.location.reload();
  }

  updateInstructor(){
    const dialogRef = this.dialog.open(UpdateInstructorDialogComponent, {
      width: '400px',
      data: { instructor: this.selectedInstructor, categories: this.categories }
    });

    dialogRef.afterClosed().subscribe(result => {

      window.location.reload();
    });
  }

  addInstructor(){
    const dialogRef = this.dialog.open(AddInstructorDialogComponent, {
      width: '400px',
      data: { categories: this.categories }
    });

    dialogRef.afterClosed().subscribe(result => {

      window.location.reload();
    });

  }

  addCategory(){
    const dialogRef = this.dialog.open(AddCategoryDialogComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {

      window.location.reload();
    });

  }

  updateCategory(){
    const dialogRef = this.dialog.open(UpdateCategoryDialogComponent, {
      width: '400px',
      data: { category: this.selectedCategory }
    });

    dialogRef.afterClosed().subscribe(result => {

      window.location.reload();
    });

  }

  deleteCategory(){
    this._categoryService.deleteCategory(this.selectedCategory.id);

    window.location.reload();
  }

  deleteResource(){
    console.log(this.selectedResource);
    this._resourceService.deleteResource(this.selectedResource.id);
    //window.location.reload();
  }

  uploadFileOnChange(event){
    this.resourceFile = <File>event.target.files[0];
  }

  giveQuizAccess(clientId: number){
    this._instructorService.giveQuizAccess(clientId);
    
    window.location.reload();
  }
  
  addResource() {
  debugger
    if (this.resourceFile != null && this.resourceName.valid) {
      this.resourceFile.arrayBuffer().then(res=> {
        var base64 = btoa(
          new Uint8Array(res)
            .reduce((data, byte) => data + String.fromCharCode(byte), '')
        );
        var newResource: IResource = {
              name: this.resourceName.value,
              file: base64,
            };
            this._resourceService.addResource(newResource);
            //window.location.reload();
      })
    }
  }

  ngOnInit() {
    this._driverService.getDrivers()
      .subscribe((data:IDriver[]) => {
        this.drivers = data.sort((a, b) => a.user.lastName?.localeCompare(b.user.lastName));
      });
    
      this._instructorService.getInstructors()
      .subscribe((data: IInstructor[]) => {
        this.instructors = data.sort((a, b) => a.user.lastName?.localeCompare(b.user.lastName));
      });
    
      this._categoryService.getCategories()
      .subscribe((data:ICategory[]) => {
        this.categories = data.sort((a, b) => a.name?.localeCompare(b.name));
      });

      this._resourceService.getResources()
      .subscribe((data:IResource[]) => {
        this.resources = data.sort((a, b) => a.name?.localeCompare(b.name));
      });

      this.resourceName = new FormControl('', [Validators.required]);
  }

}
