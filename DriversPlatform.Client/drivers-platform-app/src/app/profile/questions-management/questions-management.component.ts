import { Component, OnInit } from '@angular/core';
import { InstructorService } from 'src/app/services/instructor.service';
import { CategoryService } from 'src/app/services/category.service';
import { ICategory } from 'src/app/interfaces/category.interface';
import { MatDialog } from '@angular/material/dialog';
import { AddQuestionDialogComponent } from './add-question-dialog/add-question-dialog.component';
import { Router } from '@angular/router';
import { IQuestion } from 'src/app/interfaces/question.interface';
@Component({
  selector: 'app-questions-management',
  templateUrl: './questions-management.component.html',
  styleUrls: ['./questions-management.component.css']
})
export class QuestionsManagementComponent implements OnInit {

  questions: IQuestion[];
  searchText: string;
  categories: ICategory[];
  selectedQuestion: IQuestion;

  constructor(
    private _router:Router,
    public dialog: MatDialog,
    private _instructorService: InstructorService,
    private _categoryService: CategoryService
  ) { }

  deleteQuestion(){
    this._instructorService.deleteQuestion(this.selectedQuestion.id).subscribe();

    window.location.reload();
  }

  addQuestion(){
    const dialogRef = this.dialog.open(AddQuestionDialogComponent, {
      width: '400px',
      data: { categories: this.categories }
    });

    dialogRef.afterClosed().subscribe(result => {

      window.location.reload();
    });
  }

  searchQuestion(){
    this._instructorService.searchQuestion(this.searchText)
      .subscribe((data:any[]) => {
        this.questions = data.sort((a, b) => a.value?.localeCompare(b.value));
      });
  }

  ngOnInit(): void {
    this.searchText = "";
    this._categoryService.getCategories()
      .subscribe((data:ICategory[]) => {
        this.categories = data.sort((a, b) => a.name?.localeCompare(b.name));
      });
  }

}
