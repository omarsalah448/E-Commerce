import { Routes } from '@angular/router';
import path from 'node:path';
import { SignUpComponent } from '../Components/sign-up/sign-up.component';
import { NotFoundComponent } from '../Components/not-found/not-found.component';
import { HomeComponent } from '../Components/home/home.component';
import { UserProfileComponent } from '../Components/user-profile/user-profile.component';

export const routes: Routes = [
    {path: "", component: HomeComponent},
    {path: "Sign-Up", component: SignUpComponent},
    {path: "User-Profile/:id", component: UserProfileComponent},
    {path: "**", component: NotFoundComponent}
];
