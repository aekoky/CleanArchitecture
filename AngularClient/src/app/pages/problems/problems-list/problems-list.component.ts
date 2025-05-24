import { Component } from '@angular/core';
import { ColumnMode, NgxDatatableModule, SelectionType } from '@swimlane/ngx-datatable';
import { ProblemDto, } from 'app/web-api-client';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Observable, combineLatestWith, debounceTime, distinctUntilChanged, filter, map, startWith, switchMap } from 'rxjs';
import { DialogService } from 'app/shared/services/dialog.service';
import { ProblemService } from '../problem.service';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { Store } from '@ngrx/store';
import { problemsSelector } from '../state-management/problems.selectors';
import { deleteProblems, loadProblems, openProblem } from '../state-management/problems.actions';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { NodeLevel } from 'app/shared/models/tree.model';
import { TreeService } from '../tree.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ProblemCatalogsComponent } from '../problem-catalogs/problem-catalogs.component';
import { DirectivesModule } from 'app/shared/directives/directives.module';

@Component({
  imports: [
    MatDialogModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    ProblemCatalogsComponent,
    MatSidenavModule,
    MatMenuModule,
    NgxDatatableModule,
    DirectivesModule
  ],
  selector: 'app-problems-list',
  templateUrl: './problems-list.component.html',
  styleUrls: ['./problems-list.component.css'],
})
export class ProblemsListComponent {
  ColumnMode = ColumnMode;
  NodeLevel = NodeLevel;
  SelectionType = SelectionType;
  problems$: Observable<ProblemDto[]>;
  selectedProblems = new Array<ProblemDto>();

  filtersForm = new FormGroup({
    keyword: new FormControl(''),
  });

  constructor(
    private readonly _dialogService: DialogService,
    public problemService: ProblemService,
    public treeService: TreeService,
    private readonly _store: Store
  ) {
    const filterKeyword$ = this.filtersForm.controls.keyword.valueChanges.pipe(
      startWith(this.filtersForm.controls.keyword.value),
      debounceTime(250),
      distinctUntilChanged(),
      takeUntilDestroyed());
    const selectedNodes$ = treeService.treeSelection.changed.pipe(
      takeUntilDestroyed(),
      map(selectionChangedEvent => selectionChangedEvent.source.selected),
      startWith(treeService.treeSelection.selected),
      map(selected => {
        const categories = selected.filter(selectedNode => selectedNode.nodeLevel === NodeLevel.Category).map(selectedNode => selectedNode.id);
        const catalogs = selected.filter(selectedNode => selectedNode.nodeLevel === NodeLevel.Catalog).map(selectedNode => selectedNode.id);
        return { categories, catalogs };
      }));

    this.problems$ = _store.select(problemsSelector).pipe(
      filter(problems => !!problems?.problems),
      combineLatestWith(filterKeyword$, selectedNodes$),
      takeUntilDestroyed(),
      map(([problems, keyword, selectedNodes]) => {
        var filtredProblems = problems?.problems;
        if (keyword != null)
          filtredProblems = filtredProblems.filter(problem =>
            problem?.description?.toLocaleLowerCase()?.includes(keyword?.toLocaleLowerCase()) ||
            problem?.name?.toLocaleLowerCase()?.includes(keyword?.toLocaleLowerCase()));
        if (selectedNodes?.catalogs?.length || selectedNodes?.categories?.length)
          filtredProblems = filtredProblems.filter(problem => problem.problemCategoryId).filter(problem =>
            selectedNodes.categories?.includes(problem.problemCategoryId) ||
            problems.problemCategories.filter(problemCategory => selectedNodes.catalogs.includes(problemCategory.problemCatalogId))
              .map(problemCategory => problemCategory.id).includes(problem.problemCategoryId));
        return filtredProblems;
      }));
    this.problemService.getProblems().subscribe(problems => this._store.dispatch(loadProblems(problems)));
  }

  openProblemDialog(problemDto?: ProblemDto): void {
    this._store.dispatch(openProblem(problemDto));
    this._dialogService.dialog(EntityType.Problem).pipe(
      switchMap(matDialogRef => matDialogRef.afterClosed()))
      .subscribe();
  }

  deleteProblem(problemId: number) {
    this.problemService.deleteProblem(problemId).subscribe();
  }

  deleteProblems() {
    const selectedProblemsIds = this.selectedProblems.map(problem => problem.id);
    if (selectedProblemsIds?.length)
      this.problemService.deleteProblems(selectedProblemsIds).subscribe(() => this._store.dispatch(deleteProblems({ ids: selectedProblemsIds })));
  }
  
  onSelect({ selected }) {
    this.selectedProblems.splice(0, this.selectedProblems.length);
    this.selectedProblems.push(...selected);
  }

  getId(row) {
    return row?.id;
  }
}
