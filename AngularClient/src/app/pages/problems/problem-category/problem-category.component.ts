import { Component, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProblemCategoryDto } from 'app/web-api-client';
import { Subject, takeUntil, tap } from 'rxjs';
import { DialogService } from 'app/shared/services/dialog.service';
import { ProblemCategoryService } from '../problem-category.service';
import { Store } from '@ngrx/store';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { problemsCategorySelector as problemCategorySelector } from '../state-management/problems.selectors';

@Component({
  selector: 'app-problem-category',
  templateUrl: './problem-category.component.html',
  styleUrls: ['./problem-category.component.css'],
  standalone: false
})
export class ProblemCategoryComponent implements OnDestroy {
  private readonly _unsubscribeAll: Subject<any> = new Subject<any>();

  problemCategoryId: number;
  problemCategory: ProblemCategoryDto;
  problemCategoryForm = new FormGroup({
    id: new FormControl<number>(0),
    name: new FormControl('', [Validators.required, Validators.maxLength(250)]),
    description: new FormControl('', [Validators.maxLength(1500)]),
    problemCatalogId: new FormControl<number>(undefined)
  });

  constructor(
    private readonly _dialogService: DialogService,
    private readonly _problemCategoryService: ProblemCategoryService,
    private readonly _store: Store
  ) {
    this._store.select(problemCategorySelector).pipe(takeUntil(this._unsubscribeAll)).subscribe(problemCategory => {
      if (problemCategory) {
        this.problemCategoryId = problemCategory.id;
        this.problemCategoryForm.patchValue(problemCategory);
      }
    });
  }

  saveProblemCategory() {
    if (this.problemCategoryForm.invalid)
      return;
    this.problemCategoryForm.disable({ emitEvent: false });
    this.problemCategory = ProblemCategoryDto.fromJS(this.problemCategoryForm.getRawValue());
    this._problemCategoryService.saveProblemCategory(this.problemCategoryId, this.problemCategory).subscribe((problemCategory) => {
      this.problemCategory = problemCategory;
      this._dialogService.closeDialog(EntityType.ProblemCategory, this.problemCategory);
    })
  }

  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next(null);
    this._unsubscribeAll.complete();
  }
}
