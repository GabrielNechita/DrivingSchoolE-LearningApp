import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import { LoginModule } from './login/login.module';
import { HomeModule } from './home/home.module';
import { SignupModule } from './signup/signup.module';
import { UserService } from './services/user.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { HttpClientModule } from '@angular/common/http';
import { ProfileModule } from './profile/profile.module';
import { SharedModule } from './shared/shared.module';
import { DriverService } from './services/driver.service';
import { InstructorService } from './services/instructor.service';
import { CategoryService } from './services/category.service';
import { QuizModule } from './quiz/quiz.module';
import { ResourcesModule } from './resources/resources.module';
import { ResourceService } from './services/resource.service';
import { ContactModule } from './contact/contact.module';
import { AboutModule } from './about/about.module';

@NgModule({
  declarations: [
    AppComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HomeModule,
    SharedModule,
    LoginModule,
    SignupModule,
    ProfileModule,
    ContactModule,
    AboutModule,
    QuizModule,
    ResourcesModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule,
    MatSnackBarModule,
    HttpClientModule
  ],
  providers: [
    UserService,
    DriverService,
    InstructorService,
    CategoryService,
    ResourceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
