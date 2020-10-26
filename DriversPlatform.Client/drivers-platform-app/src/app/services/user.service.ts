import { Injectable, Output, EventEmitter } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';

@Injectable()
export class UserService{

    constructor(private _http: HttpClient, private _snackBar: MatSnackBar, private _router: Router){}
    
    signup(newUser) {
        this._http.post('https://localhost:44351/api/user/signup', newUser).subscribe({
            next: data => {
                if(data){
                    this._router.navigate((['/login']));
                    this._snackBar.open(`Success`, 'X', {
                        duration: 4000,
                    });
                }
            },
            error: error => {
                if (error.status == 400) {
                    this._snackBar.open(`Adresa de email este indisponibila!`, 'X', {
                        duration: 4000,
                    });
                }
                else{
                    this._snackBar.open(`Server Error!`, 'X', {
                        duration: 4000,
                    });
                }   
            }  
        });
    }


    login(creds) {
        return this._http.post("https://localhost:44351/api/user/login", creds)
            .pipe(
                map((data: any) => {
                    localStorage.setItem('token', data.token);
                    localStorage.setItem("expires_at", data.expiration );
                    localStorage.setItem("userRole", data.userRole[0] );
                    localStorage.setItem("email", data.email );
                    return true;
                    }));                  
      }
      
}