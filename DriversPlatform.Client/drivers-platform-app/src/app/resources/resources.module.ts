import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResourcesComponent } from './resources.component';
import { SharedModule } from '../shared/shared.module';
import { MatCardModule } from '@angular/material/card';
import {MatListModule} from '@angular/material/list';


@NgModule({
  declarations: [ResourcesComponent],
  imports: [
    CommonModule,
    SharedModule,
    MatCardModule,
    MatListModule,
    
  ]
})
export class ResourcesModule { }
