import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable, from, map } from 'rxjs';
import { ComponentType } from '@angular/cdk/overlay';
import { EntityType } from '../enums/entity-type.enum';

@Injectable({
    providedIn: 'any'
})
export class DialogService {
    private static readonly _dialogs = new Map<EntityType, MatDialogRef<any>>;
    private readonly _config = {
        autoFocus: true,
        width: 'auto',
        height: 'auto',
        maxHeight: '90vh',
        maxWidth: '100vw',
        panelClass: ['p-2', 'h-auto', 'w-auto', 'overflow-hidden'],
        disableClose: true
    };

    public dialog(type: EntityType): Observable<MatDialogRef<any>> {
        let dialogComponent: Promise<ComponentType<any>>;
        switch (type) {
            case EntityType.Problem:
                dialogComponent = import('app/pages/problems/problems.module')
                    .then(m => m.ProblemsModule)
                    .then((m) => m.components.ProblemComponent);
                break;
            case EntityType.ProblemCatalog:
                dialogComponent = import('app/pages/problems/problems.module')
                    .then(m => m.ProblemsModule)
                    .then((m) => m.components.ProblemCatalogComponent);
                break;

            case EntityType.ProblemCategory:
                dialogComponent = import('app/pages/problems/problems.module')
                    .then(m => m.ProblemsModule)
                    .then((m) => m.components.ProblemCategoryComponent);
                break;
        }

        if (!dialogComponent)
            throw new Error('Dialog Type not defined');
        return from(dialogComponent).pipe(map(component => {
            let dialogRef = this._dialog.open(component, this._config);
            DialogService._dialogs.set(type, dialogRef);
            dialogRef.afterClosed().subscribe(() => DialogService._dialogs.delete(type));
            return dialogRef;
        }));
    }

    closeDialog(type: EntityType, result: any) {
        if (DialogService._dialogs.has(type)) {
            DialogService._dialogs.get(type).close(result);
            DialogService._dialogs.delete(type);
        }
    }

    constructor(
        private readonly _dialog: MatDialog
    ) {
    }
}