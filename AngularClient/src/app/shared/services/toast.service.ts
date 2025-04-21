import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ToastType } from '../enums/taost-type.enum';

@Injectable({
    providedIn: 'root'
})
export class ToastService {

    constructor(
        private readonly _snackBar: MatSnackBar
    ) {
    }

    openToast(message: string, type: ToastType, duration?: number) {
        switch (type) {
            case ToastType.Error:
                this._snackBar.open(message, 'X', { panelClass: ['error-snackbar'] });
                break;
            case ToastType.Info:
                this._snackBar.open(message, 'X', { panelClass: ['info-snackbar'], duration: 5000, });
                break;
            case ToastType.Success:
                this._snackBar.open(message, 'X', { panelClass: ['success-snackbar'], duration: 3000 });
                break;
        }
    }
}
