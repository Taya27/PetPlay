import { LoginComponent } from "./components/login/login.component";
import { Routes } from "@angular/router";
import { MainComponent } from "./components/main/main.component";
import { ContactsComponent } from "./components/contacts/contacts.component";
import { RegisterComponent } from "./components/register/register.component";

export const AppRoutes: Routes = [
    {
        path: 'login',
        component: LoginComponent
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
        component: RegisterComponent
    },
];