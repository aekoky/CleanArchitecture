import { Component, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProblemCatalogDto } from 'app/web-api-client';
import { Subject, takeUntil, tap } from 'rxjs';
import { DialogService } from 'app/shared/services/dialog.service';
import { ViewMode } from 'app/shared/enums/view-mode.enum';
import { EntityState } from 'app/shared/models/entity-state';
import { ProblemCatalogService } from '../problem-catalog.service';
import { Store } from '@ngrx/store';
import { selectProblemCatalogEntityState } from '../state-management/problems.selectors';
import { EntityType } from 'app/shared/enums/entity-type.enum';

@Component({
  selector: 'app-problem-catalog',
  templateUrl: './problem-catalog.component.html',
  styleUrls: ['./problem-catalog.component.css'],
  standalone: false
})
export class ProblemCatalogComponent implements OnDestroy {
  private readonly _unsubscribeAll: Subject<any> = new Subject<any>();
  private _state: EntityState;

  problemCatalogId: number;
  problemCatalog: ProblemCatalogDto;
  problemCatalogForm = new FormGroup({
    id: new FormControl<number>(0),
    name: new FormControl('', [Validators.required, Validators.maxLength(250)]),
    description: new FormControl('', [Validators.maxLength(1500)]),
  });

  constructor(
    private readonly _dialogService: DialogService,
    private readonly _problemCatalogService: ProblemCatalogService,
    private readonly _store: Store
  ) {
    this._store.select(selectProblemCatalogEntityState).pipe(takeUntil(this._unsubscribeAll), tap(state => this._state = state)).subscribe(state => {
      if (state?.entity) {
        this.problemCatalogId = state.entity.id;
        this.problemCatalogForm.patchValue(state.entity);
      }
    });
  }

  saveProblemCatalog() {
    if (this.problemCatalogForm.invalid)
      return;
    this.problemCatalogForm.disable({ emitEvent: false });
    this.problemCatalog = ProblemCatalogDto.fromJS(this.problemCatalogForm.getRawValue());
    this._problemCatalogService.saveProblemCatalog(this.problemCatalogId, this.problemCatalog).subscribe(problemCatalog => {
      this.problemCatalog = problemCatalog;
      this._dialogService.closeDialog(EntityType.ProblemCatalog, this.problemCatalog);
    })
  }

  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next(null);
    this._unsubscribeAll.complete();
  }
}
