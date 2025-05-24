import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('app/pages/problems/problems-list/problems-list.component').then(m => m.ProblemsListComponent),
        title: "CleanArchitecture - Les problèmes",
    },
];
