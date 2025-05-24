import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IProblemCategoryDto, ProblemDto } from 'app/web-api-client';
import { ProblemService } from '../problem.service';
import { DialogService } from 'app/shared/services/dialog.service';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { Store } from '@ngrx/store';
import { problemSelector } from '../state-management/problems.selectors';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { DirectivesModule } from 'app/shared/directives/directives.module';

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
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.css'],
})
export class ProblemComponent {
  problemId: number | undefined;
  problem: ProblemDto;
  problemForm = new FormGroup({
    id: new FormControl<number>(0),
    name: new FormControl('', [Validators.required, Validators.maxLength(250)]),
    description: new FormControl('', [Validators.maxLength(1500)]),
    problemCategoryId: new FormControl<number | undefined>(undefined),
    problemCategory: new FormControl<IProblemCategoryDto | undefined>(undefined)
  });

  constructor(
    private readonly _dialogService: DialogService,
    private readonly _problemService: ProblemService,
    private readonly _store: Store
  ) {
    this._store.select(problemSelector).pipe(takeUntilDestroyed()).subscribe(problem => {
      if (problem) {
        this.problemId = problem.id;
        this.problemForm.patchValue(problem);
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
}
