import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ICategory } from 'src/app/interfaces/category.interface';
import { CategoryService } from 'src/app/services/category.service';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-category-dialog',
  templateUrl: './add-category-dialog.component.html',
  styleUrls: ['./add-category-dialog.component.css']
})
export class AddCategoryDialogComponent implements OnInit {

  addForm: FormGroup;
  
  constructor(public dialogRef: MatDialogRef<AddCategoryDialogComponent>,
    public fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private _categoryService: CategoryService) {
      this.addForm = this.fb.group({
        name: new FormControl('', [Validators.required]),
        description: new FormControl(),
      });
     }

  onNoClick(): void {
    this.dialogRef.close();
  }

  addCategory(){
    if(this.addForm.valid){
        var newCategory: ICategory = {
          name: this.addForm.get('name')?.value,
          description: this.addForm.get('description')?.value,
          }
        this._categoryService.addCategory(newCategory);
        this.dialogRef.close();
    }
  }

  ngOnInit(): void {
  }

}
