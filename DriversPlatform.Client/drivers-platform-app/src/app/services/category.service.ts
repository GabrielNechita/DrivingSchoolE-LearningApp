import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { map } from 'rxjs/operators';
import { ICategory } from '../interfaces/category.interface';

@Injectable()
export class CategoryService{

    constructor(private _http: HttpClient, private _router: Router, private _snackBar: MatSnackBar) {}

    getCategories() {
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/admin/getCategories", { headers })
        .pipe(
            map((data: ICategory[]) => {   
                return data;
            }));
    }

    deleteCategory(categoryId){
        let params = new HttpParams().set("categoryId", categoryId)
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.delete("https://localhost:44351/api/admin/deleteCategory", { headers: headers, params: params })
        .pipe().subscribe({
            next: data => {
                this._snackBar.open(`Success`, 'X', {
                    duration: 4000,
                    });  
            },
            error: error => {
                this._snackBar.open(`Server Error!`, 'X', {
                    duration: 4000,
                });    
            }
        });
    }

    updateCategory(category){
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.put('https://localhost:44351/api/admin/updateCategory', category, { headers }).subscribe({
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

    addCategory(newCategory){
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.post('https://localhost:44351/api/admin/addCategory', newCategory, { headers }).subscribe({
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
}
