import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IResource } from '../interfaces/resource.interface';
import { map } from 'rxjs/operators';
import { saveAs } from 'file-saver';
@Injectable()
export class ResourceService{
 
    constructor(private _http: HttpClient, private _router: Router, private _snackBar: MatSnackBar) {}

    getResources(){
        
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.get("https://localhost:44351/api/admin/getResources", { headers })
        .pipe(
            map((data: IResource[]) => {   
                return data;
            }));
    }

    getResourceById(resourceId){
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        let params = new HttpParams().set("resourceId", resourceId)
        return this._http.get("https://localhost:44351/api/admin/getResourceById", { params: params, headers: headers, responseType: 'arraybuffer' })
        .pipe(
            map((data: any) => {   
                return data;
            }));
    
    }

    addResource(newResource){
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        this._http.post('https://localhost:44351/api/admin/addResource', newResource, { headers }).subscribe({
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

    deleteResource(resourceId){
        let params = new HttpParams().set("resourceId", resourceId)
        let headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));
        return this._http.delete("https://localhost:44351/api/admin/deleteResource", { headers: headers, params: params })
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
}