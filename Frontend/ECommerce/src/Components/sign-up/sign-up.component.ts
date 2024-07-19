import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { User } from '../../../Models/User';
import { RetypePassword } from '../../Validations/retypePassword.validator';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { Router, RouterModule } from '@angular/router';
import { catchError, of, retry, throwError } from 'rxjs';
import { response } from 'express';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent implements OnInit {
  form: FormGroup;
  countryCodes: any;
  signUpError: boolean = false;
  constructor(fb: FormBuilder, private http: HttpClient, 
              private router: Router) {
    let passwordRegex = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
    let nameRegex = "^[A-Za-z ,.'-]+$";
    let emailRegex = "[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}";
    this.form = fb.group({
      FirstName: ["", [Validators.required, Validators.pattern(nameRegex)]],
      LastName: ["", [Validators.required, Validators.pattern(nameRegex)]],
      Email: ["", [Validators.required, Validators.pattern(emailRegex)]],
      CountryCode: ["", [Validators.required]],
      // MobileNumber: ["", [Validators.required, Validators.pattern("\\d{5,}")]],
      MobileNumber: ["", [Validators.required, Validators.pattern(".*")]],
      Password: ["", [Validators.required, Validators.pattern(passwordRegex)]],
      RetypePassword: ["", [Validators.required]]
    }, { validators: RetypePassword });
  }

  ngOnInit(): void {

    this.countryCodes = [
      {country: "Argentina (+54)", code: "+54"},
      {country: "Australia (+61)", code: "+61"},
      {country: "Brazil (+55)", code: "+55"},
      {country: "Canada (+1)", code: "+1"},
      {country: "China (+86)", code: "+86"},
      {country: "Egypt (+20)", code: "+20"},
      {country: "France (+33)", code: "+33"},
      {country: "Germany (+49)", code: "+49"},
      {country: "India (+91)", code: "+91"},
      {country: "Italy (+39)", code: "+39"},
      {country: "Japan (+81)", code: "+81"},
      {country: "Mexico (+52)", code: "+52"},
      {country: "Russia (+7)", code: "+7"},
      {country: "Saudi Arabia (+966)", code: "+966"},
      {country: "South Africa (+27)", code: "+27"},
      {country: "South Korea (+82)", code: "+82"},
      {country: "Spain (+34)", code: "+34"},
      {country: "Turkey (+90)", code: "+90"},
      {country: "United Arab Emirates (+971)", code: "+971"},
      {country: "United Kingdom (+44)", code: "+44"},
      {country: "United States (+1)", code: "+1"}
    ]; 
  }
  get FirstName() {
    return this.form.get("FirstName");
  }
  get LastName() {
    return this.form.get("LastName");
  }
  get Email() {
    return this.form.get("Email");
  }
  get CountryCode() {
    return this.form.get("CountryCode");
  }
  get MobileNumber() {
    return this.form.get("MobileNumber");
  }
  get Password() {
    return this.form.get("Password");
  }
  get RetypePassword() {
    return this.form.get("RetypePassword");
  }

  signUp() {
    this.signUpError = false;
    let user: User = new User;
    user.FirstName = this.FirstName?.value;
    user.LastName = this.LastName?.value;
    user.Email = this.Email?.value;
    user.CountryCode = this.CountryCode?.value;
    user.MobileNumber = this.MobileNumber?.value;
    user.Password = this.Password?.value;
    let URL: string = `${environment.URL}/api/User`;
    this.http.post<User>(URL, user, {observe: 'response'}).pipe(
      retry(3),
      catchError(error => {
        console.error('Error occurred here:', error);
        this.handleError;
        return of(null);
      })
    ).subscribe(response => {
      console.log('Response here:', response);
      if (response?.status == 200 || response?.status == 201){
        this.router.navigate(["User-Profile", 1])
        alert("Yeeeeeeeeeeeeeeeees" + this.signUpError);}
      else{
        alert("Nooooooooooo" + this.signUpError)};
    });
    // if (!this.signUpError)
    //   this.router.navigate(["User-Profile", 1])
    // alert(this.signUpError);
  }

  getFormValidationErrors() {
    Object.keys(this.form.controls).forEach(key => {
      const controlErrors = this.form.get(key)?.errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach(keyError => {
         console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
        });
      }
    });
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
      alert('An error occurred:' + error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
        alert(`Backend returned code ${error.status}, body was: ` + error.error)
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
