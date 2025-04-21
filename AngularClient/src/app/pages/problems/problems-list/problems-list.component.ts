import { Component, OnDestroy } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { ProblemDto, } from 'app/web-api-client';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, Observable, Subject, combineLatestWith, debounceTime, distinctUntilChanged, filter, map, startWith, switchMap, take, takeUntil, tap, withLatestFrom } from 'rxjs';
import { DialogService } from 'app/shared/services/dialog.service';
import { ViewMode } from 'app/shared/enums/view-mode.enum';
import { EntityState } from 'app/shared/models/entity-state';
import { MatDialogRef } from '@angular/material/dialog';
import { ProblemService } from '../problem.service';
import { ProblemTreeService } from '../problem-tree.service';
import { NodeLevel, TreeNode } from 'app/shared/modules/tree/tree.model';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { Store } from '@ngrx/store';
import { resetProblemEntityState, setProblemEntityState } from '../state-management/problems.actions';
import { selectProblemListEntityState } from '../state-management/problems.selectors';

@Component({
  selector: 'app-problems-list',
  templateUrl: './problems-list.component.html',
  styleUrls: ['./problems-list.component.css'],
  standalone: false
})
export class ProblemsListComponent implements OnDestroy {
  ColumnMode = ColumnMode;
  NodeLevel = NodeLevel;
  SelectionType = SelectionType;
  ViewMode = ViewMode;
  private readonly _unsubscribeAll: Subject<any> = new Subject<any>();
  private readonly _problems$ = new BehaviorSubject<ProblemDto[]>([]);
  problems$: Observable<ProblemDto[]>;
  selectedProblems = new Array<ProblemDto>();
  selectedNodes = new BehaviorSubject<TreeNode[]>([]);
  state: EntityState;

  filtersForm = new FormGroup({
    keyword: new FormControl(''),
  });

  constructor(
    private readonly _dialogService: DialogService,
    public problemService: ProblemService,
    public problemTreeService: ProblemTreeService,
    private readonly _store: Store
  ) {
    _store.select(selectProblemListEntityState).pipe(takeUntil(this._unsubscribeAll))
      .subscribe(state => {
        this.state = state;
        if (state?.filters)
          this.filtersForm.patchValue(state.filters);
        else
          this.filtersForm.reset();

        this.problems$ = this._problems$.pipe(
          combineLatestWith(
            this.filtersForm.controls.keyword.valueChanges.pipe(
              takeUntil(this._unsubscribeAll),
              startWith(this.filtersForm.controls.keyword.value),
              debounceTime(250),
              distinctUntilChanged())),
          map(([problems, keyword]) => {
            if (keyword != null)
              problems = problems.filter(problem =>
                problem?.description?.toLocaleLowerCase()?.includes(keyword?.toLocaleLowerCase()) ||
                problem?.name?.toLocaleLowerCase()?.includes(keyword?.toLocaleLowerCase()));
            return problems;
          }));
        this.getProblem();
      });

    this.selectedNodes.pipe(
      takeUntil(this._unsubscribeAll),
      map(selectedNodes => {
        const categories = selectedNodes.filter(selectedNode => selectedNode.nodeLevel === NodeLevel.Category).map(selectedNode => selectedNode.id);
        const catalogs = selectedNodes.filter(selectedNode => selectedNode.nodeLevel === NodeLevel.Catalog).map(selectedNode => selectedNode.id);
        return { categories, catalogs };
      }),
      switchMap(filters => this.problemService.getProblemsByCategory(filters.categories, filters.catalogs)))
      .subscribe(this._problems$);
  }

  ngOnDestroy(): void {
    this._unsubscribeAll.next(null);
    this._unsubscribeAll.complete();
  }

  openProblemDialog(problemDto?: ProblemDto): void {
    var dialogObservable: Observable<MatDialogRef<any, any>>;
    if (problemDto) {
      this._store.dispatch(setProblemEntityState({
        viewMode: ViewMode.Dialog, entity: problemDto
      }));
      dialogObservable = this._dialogService.dialog(EntityType.Problem);
    }
    else {
      this._store.dispatch(resetProblemEntityState());
      dialogObservable = this._dialogService.dialog(EntityType.Problem);
    }
    dialogObservable.pipe(
      switchMap(matDialogRef => matDialogRef.afterClosed()),
      filter(problem => !!problem?.id),
      withLatestFrom(this._problems$))
      .subscribe(([savedProblem, problems]) => {
        const problemIndex = problems.findIndex(problem => problem.id === savedProblem?.id);
        if (problemIndex !== -1)
          problems[problemIndex] = savedProblem;
        else
          problems.push(savedProblem);
        this._problems$.next([...problems]);
      });
  }

  deleteProblem(problemId: number) {
    this.problemService.deleteProblem(problemId).pipe(
      switchMap(() => this._problems$.pipe(take(1)))
    ).subscribe(
      (problems) => {
        const problemIndex = problems.findIndex(problem => problem.id === problemId);
        if (problemIndex !== -1)
          problems.splice(problemIndex, 1);
        this._problems$.next(problems);
      });
  }

  deleteProblems() {
    const selectedProblemsIds = this.selectedProblems.map(problem => problem.id);
    if (selectedProblemsIds?.length)
      this.problemService.deleteProblems(selectedProblemsIds).subscribe(() => {
        this._problems$.pipe(take(1)).subscribe(
          (problems) => {
            problems = problems.filter(problem => !selectedProblemsIds.includes(problem.id));
            this.selectedProblems = [];
            this._problems$.next(problems);
          });
      });
  }

  getProblem() {
    this.problemService.getProblems().subscribe(problems => this._problems$.next(problems));
  }

  onActivate(event) {
    if (event?.type === 'dblclick' && event?.row?.id)
      this.openProblemDialog(event.row);
  }

  getId(row) {
    return row?.id;
  }
}
