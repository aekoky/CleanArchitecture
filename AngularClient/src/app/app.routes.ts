import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('app/pages/problems/problems.module').then(m => m.ProblemsModule),
    },
];
