import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile.component';
import { DriverProfileComponent } from './driver-profile/driver-profile.component';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';
import { InstructorProfileComponent } from './instructor-profile/instructor-profile.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UpdateDialogComponent } from './driver-profile/update-dialog/update-dialog.component';
import { AddInstructorDialogComponent } from './admin-profile/add-instructor-dialog/add-instructor-dialog.component';
import { UpdateInstructorDialogComponent } from './admin-profile/update-instructor-dialog/update-instructor-dialog.component';
import { UpdateCategoryDialogComponent } from './admin-profile/update-category-dialog/update-category-dialog.component';
import { AddCategoryDialogComponent } from './admin-profile/add-category-dialog/add-category-dialog.component';
import { QuestionsManagementComponent } from './questions-management/questions-management.component';
import { AddQuestionDialogComponent } from './questions-management/add-question-dialog/add-question-dialog.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import {MatListModule} from '@angular/material/list';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatSelectModule} from '@angular/material/select';
import {MatDividerModule} from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card';
import {MatRadioModule} from '@angular/material/radio';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatTabsModule} from '@angular/material/tabs';
import {MatTableModule} from '@angular/material/table';
import { MaterialFileInputModule } from 'ngx-material-file-input';

@NgModule({
  declarations: [
    ProfileComponent, 
    DriverProfileComponent, 
    AdminProfileComponent, 
    InstructorProfileComponent, 
    UpdateDialogComponent, 
    AddInstructorDialogComponent, 
    UpdateInstructorDialogComponent, 
    UpdateCategoryDialogComponent, 
    AddCategoryDialogComponent, QuestionsManagementComponent, AddQuestionDialogComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatTooltipModule,
    MatDatepickerModule,
    MatSelectModule,
    FormsModule,
    MatNativeDateModule,
    MatSnackBarModule,
    MatDividerModule,
    MatCardModule,
    MatDialogModule,
    MatRadioModule,
    MatExpansionModule,
    MatTabsModule,
    MatTableModule,
    MaterialFileInputModule,
  ],
  entryComponents: [UpdateDialogComponent],

})
export class ProfileModule { }
