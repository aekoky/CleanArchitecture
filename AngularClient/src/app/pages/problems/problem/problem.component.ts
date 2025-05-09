import { Component, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProblemDto } from 'app/web-api-client';
import { Subject, takeUntil, tap } from 'rxjs';
import { ProblemService } from '../problem.service';
import { DialogService } from 'app/shared/services/dialog.service';
import { ViewMode } from 'app/shared/enums/view-mode.enum';
import { EntityState } from 'app/shared/models/entity-state';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { Store } from '@ngrx/store';
import { selectProblemEntityState } from '../state-management/problems.selectors';

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.css'],
  standalone: false
})
export class ProblemComponent implements OnDestroy {
  private readonly _unsubscribeAll: Subject<any> = new Subject<any>();
  problemId: number | undefined;
  problem: ProblemDto;
  problemForm = new FormGroup({
    id: new FormControl<number>(0),
    name: new FormControl('', [Validators.required, Validators.maxLength(250)]),
    description: new FormControl('', [Validators.maxLength(1500)]),
    problemCategoryId: new FormControl<number | undefined>(undefined)
  });

  constructor(
    private readonly _dialogService: DialogService,
    private readonly _problemService: ProblemService,
    private readonly _store: Store
  ) {
    this._store.select(selectProblemEntityState).pipe(takeUntil(this._unsubscribeAll)).subscribe(state => {
      if (state?.entity) {
        this.problemId = state.entity.id;
        this.problemForm.patchValue(state.entity);
      }
    });
  }

  saveProblem() {
    if (this.problemForm.invalid)
      return;
    this.problemForm.disable({ emitEvent: false });
    this.problem = ProblemDto.fromJS(this.problemForm.getRawValue());
    this._problemService.saveProblem(this.problemId, this.problem).subscribe((problem) => {
      this.problem = problem;
      this._dialogService.closeDialog(EntityType.Problem, this.problem);
    });
  }

  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next(null);
    this._unsubscribeAll.complete();
  }
}
