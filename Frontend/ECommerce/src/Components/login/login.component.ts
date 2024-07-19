import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  form: FormGroup;
  countryCodes: any;
  constructor(fb: FormBuilder, private http: HttpClient, private router: Router) {
    this.form = fb.group({
      Email: ["", [Validators.required]],
      Password: ["", [Validators.required]]
    });
  }

  get Email() {
    return this.form.get("Email");
  }
  get Password() {
    return this.form.get("Password");
  }

  login() {

  }
}
