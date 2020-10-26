import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { map, catchError } from 'rxjs/operators';
import { IDriver } from '../interfaces/driver.interface';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ICategory } from '../interfaces/category.interface';
import { IQuestion } from '../interfaces/question.interface';

@Injectable()
export class DriverService{

    constructor(private _http: HttpClient, private _router: Router, private _snackBar: MatSnackBar){}

    public driver: IDriver;

    getDriverByEmail(){
        let params = new HttpParams().set("email", localStorage.getItem('email'));
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/driver/getDriverByEmail", { headers: headers, params: params })
        .pipe(
            map((data: IDriver) => {                
                this.driver = data;
                return data;
            }));

    }

    updateDriver(driver: any) {
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.put('https://localhost:44351/api/driver/updateDriver', driver, {headers}).subscribe({
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

    addCategoryToDriver(driverId, categoryName){
        let params = new HttpParams().set("driverId", driverId)
                                        .set("categoryName", categoryName);
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.post('https://localhost:44351/api/driver/addCategoryToDriver', driverId, { headers: headers, params: params }).subscribe({
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

    addInstructorToDriver(driverId, instructorId){
        let params = new HttpParams().set("driverId", driverId)
                                    .set("instructorId", instructorId);
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.post('https://localhost:44351/api/driver/addInstructorToDriver', driverId, { headers: headers, params: params }).subscribe({
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


    getDrivers() {
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/admin/getDrivers", { headers })
        .pipe(
            map((data: IDriver[]) => {   
                return data;
            }));
      }
      
      deleteDriver(driverId) {
        let params = new HttpParams().set("driverId", driverId)
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.delete("https://localhost:44351/api/admin/deleteDriver", { headers: headers, params: params })
        .pipe(
            
        );
      }

      getQuizByDifficultyAndCategory(categoryId, difficulty) {
        let params = new HttpParams().set("categoryId", categoryId)
                                    .set("difficulty", difficulty);
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/driver/getQuizByDifficultyAndCategory", { headers: headers, params: params })
        .pipe(
            map((data: IQuestion[]) => { 
                return data;
            }));                            

      }
      getMixQuizByCategory(categoryId) {
        let params = new HttpParams().set("categoryId", categoryId);
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/driver/getQuizByCategory", { headers: headers, params: params })
        .pipe(
            map((data: IQuestion[]) => { 
                return data;
            }));

      }

    addQuizResult(newResult) {
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.post('https://localhost:44351/api/driver/addQuizResult', newResult, { headers }).subscribe({
            next: data => {
                if(data){
                    this._snackBar.open(`Success: Rezultat trimis`, 'X', {
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
    

}