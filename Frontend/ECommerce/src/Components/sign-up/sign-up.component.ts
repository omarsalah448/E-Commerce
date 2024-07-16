import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { User } from '../../../Models/User';
import { RetypePassword } from '../../Validations/retypePassword.validator';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent implements OnInit {
  form: FormGroup;
  countryCodes: any;
  constructor(fb: FormBuilder, private http: HttpClient) {
    let passwordRegex = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
    let nameRegex = "^[a-z ,.'-]+$";
    let emailRegex = "[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}";
    this.form = fb.group({
      FirstName: ["", [Validators.required, Validators.pattern(nameRegex)]],
      LastName: ["", [Validators.required, Validators.pattern(nameRegex)]],
      Email: ["", [Validators.required, Validators.pattern(emailRegex)]],
      CountryCode: ["", [Validators.required]],
      MobileNumber: ["", [Validators.required, Validators.pattern("[0-9]")]],
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
    alert("in sign up");
    let user: User = new User;
    user.FirstName = this.FirstName?.value;
    user.LastName = this.LastName?.value;
    user.Email = this.Email?.value;
    user.CountryCode = this.CountryCode?.value;
    user.MobileNumber = this.MobileNumber?.value;
    user.Password = this.Password?.value;
    let URL: string = `${environment.URL}/api/User`;
    this.http.post<User>(URL, user).subscribe(user => {
      console.log(user);
    });
    alert("finished");
  }
}
