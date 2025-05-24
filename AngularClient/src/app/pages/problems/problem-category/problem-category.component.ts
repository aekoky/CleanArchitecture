import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProblemCategoryDto } from 'app/web-api-client';
import { DialogService } from 'app/shared/services/dialog.service';
import { ProblemCategoryService } from '../problem-category.service';
import { Store } from '@ngrx/store';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { problemsCategorySelector as problemCategorySelector } from '../state-management/problems.selectors';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DirectivesModule } from 'app/shared/directives/directives.module';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { MatIconModule } from '@angular/material/icon';

@Component({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    DirectivesModule],
  selector: 'app-problem-category',
  templateUrl: './problem-category.component.html',
  styleUrls: ['./problem-category.component.css'],
})
export class ProblemCategoryComponent {
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
    this._store.select(problemCategorySelector).pipe(takeUntilDestroyed()).subscribe(problemCategory => {
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
}
