import { Component, OnInit, Inject } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-update-category-dialog',
  templateUrl: './update-category-dialog.component.html',
  styleUrls: ['./update-category-dialog.component.css']
})
export class UpdateCategoryDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<UpdateCategoryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _categoryService: CategoryService) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  updateCategory(){
    this._categoryService.updateCategory(this.data.category);
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }

}
