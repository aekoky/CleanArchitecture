import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProblemCatalogDto } from 'app/web-api-client';
import { DialogService } from 'app/shared/services/dialog.service';
import { ProblemCatalogService } from '../problem-catalog.service';
import { Store } from '@ngrx/store';
import { problemCatalogSelector } from '../state-management/problems.selectors';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { DirectivesModule } from 'app/shared/directives/directives.module';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    DirectivesModule],
  selector: 'app-problem-catalog',
  templateUrl: './problem-catalog.component.html',
  styleUrls: ['./problem-catalog.component.css'],
})
export class ProblemCatalogComponent {
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
    this._store.select(problemCatalogSelector).pipe(takeUntilDestroyed()).subscribe(problemCatalog => {
      if (problemCatalog) {
        this.problemCatalogId = problemCatalog.id;
        this.problemCatalogForm.patchValue(problemCatalog);
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
}
