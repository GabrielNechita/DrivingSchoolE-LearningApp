import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DriverService } from 'src/app/services/driver.service';

@Component({
  selector: 'app-update-dialog',
  templateUrl: './update-dialog.component.html',
  styleUrls: ['./update-dialog.component.css']
})
export class UpdateDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<UpdateDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _router: Router,
    private _driverService: DriverService) { }

    onNoClick(): void {
      this.dialogRef.close();
    }

    update(){
      this._driverService.updateDriver(this.data.driver);
      this.dialogRef.close();
    }

  ngOnInit() {
  }

}
