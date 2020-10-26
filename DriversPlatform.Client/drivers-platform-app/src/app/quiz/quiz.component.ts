import { Component, OnInit } from '@angular/core';
import { IDriver } from '../interfaces/driver.interface';
import { DriverService } from '../services/driver.service';
import { IQuestion } from '../interfaces/question.interface';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit {

  constructor(private _driverService: DriverService) { }

  difficulty: string;
  driver: IDriver;
  hasAccess: boolean;
  showIntro: boolean;
  quiz: IQuestion[];
  questionNumber: number = 0;
  selectedAnswers: any[] = [];
  correctAnswers: any[];
  score: number;
  quizIsOver: boolean;
  showCorrectAnswers: boolean;

  generateQuiz(){
    this.quizIsOver = false;
    this.score = 0;
    this.showIntro = false;
    if(this.difficulty == 'mix'){
      this._driverService.getMixQuizByCategory(this.driver.category.id)
      .subscribe((data:IQuestion[]) => {
        this.quiz = data;
      });
    }else{
      this._driverService.getQuizByDifficultyAndCategory(this.driver.category.id, this.difficulty)
        .subscribe((data:IQuestion[]) => {
          this.quiz = data;
        });
    }
    this.questionNumber = 0;
  }

  isDriverCorrect(): boolean{
    var aux = 1;
    if (this.selectedAnswers.length != this.correctAnswers.length) {
      aux = 0;
    }else{
      this.correctAnswers.forEach(element => {
        if (!this.selectedAnswers.find(x => x.value == element.value)) {
          aux = 0;
        }
      });
    }

    if (aux == 1) {
      return true;
    }else{
      return false;
    }
  }

  showCorrect(){
    this.showCorrectAnswers = true;
  }

  nextQuestion(){
    this.showCorrectAnswers = false;
    this.correctAnswers = [];
    this.quiz[this.questionNumber].answers.forEach(element => {
      if (element.isCorrect) {
        this.correctAnswers.push(element);
      }
    });

    if (this.isDriverCorrect()) {
      this.score ++;
    }

    this.questionNumber ++;

    if (this.questionNumber == this.quiz.length) {
      this.quizIsOver = true; 
      this.sendResult();
    }
  }

  sendResult(){
    var newResult = {
      score: this.score,
      driverId: this.driver.id,
      categoryId: this.driver.category.id,
      difficulty: this.difficulty
    }
    this._driverService.addQuizResult(newResult);
  }

  ngOnInit(): void {
    this.quiz = []; 
    this.showIntro = true;
    this.difficulty = 'easy';
    this.hasAccess = false;
    this._driverService.getDriverByEmail()
    .subscribe((data:IDriver) => {
      this.driver = data;
      this.hasAccess = this.driver.hasQuizAccess;
      console.log(this.driver);
    });
    this.questionNumber = 0;
    this.score = 0;
  }

}
