import { NgModule } from '@angular/core';
import { CloseDialogDirective } from './close-dialog.directive';
import { ColumnModeDirective } from './column-mode.directive';
import { ScrollToInvalideDirective } from './scroll-to-invalide.directive';
import { OnlyDialogDirective } from './only-dialog.directive';

@NgModule({
    imports: [],
    declarations: [
        ScrollToInvalideDirective,
        CloseDialogDirective,
        ColumnModeDirective,
        OnlyDialogDirective
    ],
    exports: [
        ScrollToInvalideDirective,
        CloseDialogDirective,
        ColumnModeDirective,
        OnlyDialogDirective
    ]
})
export class DirectivesModule { }