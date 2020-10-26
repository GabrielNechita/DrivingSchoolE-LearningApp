import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { InstructorService } from 'src/app/services/instructor.service';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ICategory } from 'src/app/interfaces/category.interface';
import { IQuestion } from 'src/app/interfaces/question.interface';
import { IAnswer } from 'src/app/interfaces/answer.interface';

@Component({
  selector: 'app-add-question-dialog',
  templateUrl: './add-question-dialog.component.html',
  styleUrls: ['./add-question-dialog.component.css']
})
export class AddQuestionDialogComponent implements OnInit {

  numberOfAnswers:number;
  questionValue: FormControl;
  difficulty: string;
  selectedCategory: ICategory;
  numbers: any[];
  answersValues: FormControl[];
  asnwersIsCorrectValue: FormControl[];
  questionImage: File;

  typesOfShoes: string[] = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];
  constructor(public dialogRef: MatDialogRef<AddQuestionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _instructorService: InstructorService,
    private _snackBar: MatSnackBar) {}

  uploadFileOnChange(event){
    this.questionImage = <File>event.target.files[0];
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  setNumber(){
    this.numbers = Array(this.numberOfAnswers).fill(0).map((x,i)=>i);
    this.numbers.forEach(number => {
      this.answersValues[number] = new FormControl('', [Validators.required]);
      this.asnwersIsCorrectValue[number] = new FormControl('true');
    });
    console.log(this.asnwersIsCorrectValue);
  }

  formIsValid(): boolean{
    if (this.questionValue.valid && this.selectedCategory != null) {
      for (let index = 0; index < this.answersValues.length; index++) {
        if (!this.answersValues[index].valid) {
          return false;
        }
      }
      return true;
    }
    return false;
  }

  addQuestion(){
    let answersList = new Array<IAnswer>();
    this.numbers.forEach(number => {
      answersList.push({
        value: this.answersValues[number].value,
        isCorrect: this.asnwersIsCorrectValue[number].value
      });
    });

    let newQuestion: IQuestion = {
      value: this.questionValue.value,
      categoryId: this.selectedCategory[0].id,
      difficulty: this.difficulty,
      answers: answersList,
      image: null,
    };
    if (this.questionImage != null) {
      this.questionImage
        .stream()
        .getReader()
        .read()
        .then((res) => {
          var boa = btoa(String.fromCharCode(...res.value));
          (newQuestion.image = boa),
            this._instructorService.addQuestion(newQuestion);
          this.dialogRef.close();
        });
    } else {
      this._instructorService.addQuestion(newQuestion);
      this.dialogRef.close();
    }
  }

  ngOnInit(): void {

    this.difficulty = 'easy';
    this.questionValue = new FormControl('', [Validators.required]);
    this.answersValues = new Array<FormControl>();
    this.asnwersIsCorrectValue = new Array<FormControl>();
    this.numberOfAnswers = 2;
    this.setNumber();
  }

}
