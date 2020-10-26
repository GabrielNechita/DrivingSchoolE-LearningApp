import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IInstructor } from '../interfaces/instructor.interface';
import { map } from 'rxjs/operators';
import { IQuestion } from '../interfaces/question.interface';

@Injectable()
export class InstructorService{
  
    constructor(private _http: HttpClient, private _router: Router, private _snackBar: MatSnackBar) { }

    instructors: IInstructor[];
    instructor: IInstructor;

    getInstructorByEmail(){
        let params = new HttpParams().set("email", localStorage.getItem('email'));
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/instructor/getInstructorByEmail", { headers: headers, params: params })
        .pipe(
            map((data: IInstructor) => {                
                this.instructor = data;
                return data;
            }));

    }

    getInstructorsByCategory(category: string){
        let params = new HttpParams().set("category", category);
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/instructor/getInstructorsByCategory", { headers: headers, params: params })
        .pipe(
            map((data: IInstructor[]) => {                
                this.instructors = data;
                return data;
            }));
    }

    getInstructors() {
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/admin/getInstructors", { headers })
        .pipe(
            map((data: IInstructor[]) => {                
                this.instructors = data;
                return data;
            }));
      }

      deleteInstructor(instructorId) {
        let params = new HttpParams().set("instructorId", instructorId)
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.delete("https://localhost:44351/api/admin/deleteInstructor", { headers: headers, params: params })
        .pipe(
            
        );
      }

    addInstructor(newInstructor){
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.post('https://localhost:44351/api/admin/addInstructor', newInstructor, { headers }).subscribe({
            next: data => {
                if(data){
                    this._snackBar.open(`Success`, 'X', {
                        duration: 4000,
                    });
                }
            },
            error: error => {
                if(error.status == 400){
                    this._snackBar.open(`Adresa de email indisponibila!`, 'X', {
                        duration: 4000,
                    });
                }else{
                    this._snackBar.open(`Server Error!`, 'X', {
                        duration: 4000,
                    });
                }       
            }
        });
    }

    updateInstructor(instructor){
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.put('https://localhost:44351/api/instructor/updateInstructor', instructor, {headers}).subscribe({
            next: data => {
                if(data){
                    this._snackBar.open(`Success`, 'X', {
                        duration: 4000,
                    });
                }
            },
            error: error => {
                this._snackBar.open(`Server Error!`, 'X', {
                    duration: 4000,
                });
            }
        });
    }

    searchQuestion(searchText: string){
        let params = new HttpParams().set("searchText", searchText);
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/instructor/searchQuestion", { headers: headers, params: params })
        .pipe(
            map((data: IInstructor[]) => {                
                this.instructors = data;
                return data;
            }));
    }

    addQuestion(newQuestion: IQuestion) {
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.post('https://localhost:44351/api/instructor/addQuestion', newQuestion, { headers }).subscribe({
            next: data => {
                if(data){
                    this._snackBar.open(`Success`, 'X', {
                    duration: 4000,
                    });
                }
            },
            error: error => {
                console.log(error)
                this._snackBar.open(`Server Error!`, 'X', {
                    duration: 4000,
                });    
            }
        });
    }
    deleteQuestion(questionId) {
        let params = new HttpParams().set("questionId", questionId)
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.delete("https://localhost:44351/api/instructor/deleteQuestion", { headers: headers, params: params })
        .pipe();
    }

    giveQuizAccess(clientId: number) {
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.post('https://localhost:44351/api/instructor/giveQuizAccess', clientId, { headers }).subscribe({
            next: data => {
                if(data){
                    this._snackBar.open(`Success`, 'X', {
                    duration: 4000,
                    });
                }
            },
            error: error => {
                console.log(error)
                this._snackBar.open(`Error!`, 'X', {
                    duration: 4000,
                });    
            }
        });
    }
    
}