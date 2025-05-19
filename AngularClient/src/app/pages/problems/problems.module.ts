import { inject, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProblemsListComponent } from './problems-list/problems-list.component';
import { Route, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { ProblemsComponent } from './problems.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { DirectivesModule } from 'app/shared/directives/directives.module';
import { ProblemCatalogComponent } from './problem-catalog/problem-catalog.component';
import { ProblemCategoryComponent } from './problem-category/problem-category.component';
import { ProblemComponent } from './problem/problem.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatBadgeModule } from '@angular/material/badge';
import { ProblemCatalogsComponent } from './problem-catalogs/problem-catalogs.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from '@angular/material/divider';
import { MatTreeModule } from '@angular/material/tree';

const problemsRoutes: Route[] = [
  {
    path: '',
    component: ProblemsComponent,
    children: [
      {
        path: '',
        component: ProblemsListComponent,
        title: "CleanArchitecture - Les problèmes",
      }
    ]
  }
];


@NgModule({
  declarations: [
    ProblemsListComponent,
    ProblemsComponent,
    ProblemComponent,
    ProblemCategoryComponent,
    ProblemCatalogComponent,
    ProblemCatalogsComponent,
  ],
  imports: [
    RouterModule.forChild(problemsRoutes),
    MatDialogModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    NgxDatatableModule,
    MatPaginatorModule,
    MatMenuModule,
    DirectivesModule,
    MatSidenavModule,
    MatBadgeModule,
    MatDividerModule,
    MatTreeModule,
    MatCheckboxModule,
    MatDividerModule
  ]
})
export class ProblemsModule {
  public static components = {
    ProblemComponent,
    ProblemCategoryComponent,
    ProblemCatalogComponent,
  };
}
