import { LoginComponent } from "./components/login/login.component";
import { Routes } from "@angular/router";
import { MainComponent } from "./components/main/main.component";
import { ContactsComponent } from "./components/contacts/contacts.component";
import { RegisterComponent } from "./components/register/register.component";
import { UserLoginedGuard } from "./user-logined.guard";
import { ProfileComponent } from "./components/profile/profile.component";
import { UserNotLoginedGuard } from "./user-not-logined.guard";
import { ToyConnectionComponent } from "./components/toy-connection/toy-connection.component";

export const AppRoutes: Routes = [
    { path: '', component: MainComponent },
    
    {
        path: 'login',
        component: LoginComponent,
        canActivate: [UserLoginedGuard]
    },
    {
        path: "main",
        component: MainComponent
    },
    {
        path: "contacts",
        component: ContactsComponent
    },
    {
        path: "register",
        component: RegisterComponent,
        canActivate: [UserLoginedGuard]
    },
    {
        path: "profile",
        component: ProfileComponent,
        canActivate: [UserNotLoginedGuard]
    },
    {
        path: "toy-connection",
        component: ToyConnectionComponent,
        canActivate: [UserNotLoginedGuard]
    },
    { path: '**', component: MainComponent },
];