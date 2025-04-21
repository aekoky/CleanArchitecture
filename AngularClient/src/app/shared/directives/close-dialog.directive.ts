import { Directive, Input, OnDestroy, Optional, TemplateRef, ViewContainerRef } from "@angular/core";
import { BehaviorSubject, debounceTime, fromEvent, Subject, takeUntil } from "rxjs";
import { MatDialogRef } from "@angular/material/dialog";
import { FormGroup } from "@angular/forms";

@Directive({
  selector: '[appCloseDialog]',
  standalone: false
})
export class CloseDialogDirective implements OnDestroy {
  private readonly _unsubscribeAll: Subject<any> = new Subject<any>();
  private readonly deviceView$ = new BehaviorSubject<boolean>(false);
  private _dialogForm: FormGroup
  private _created: boolean;

  constructor(
    @Optional() private readonly _matDialogRef: MatDialogRef<any>,
    viewContainer: ViewContainerRef,
    templateRef: TemplateRef<any>
  ) {
    this.deviceView$.subscribe(show => {
      if (show) {
        if (!this._created) {
          var embeddedView = viewContainer.createEmbeddedView(templateRef);
          this.listenToClick(embeddedView.rootNodes[0]);
        }
        this._created = true;
      } else if (this._created)
        viewContainer.clear();
    });
    this.deviceView$.next(!!_matDialogRef);
  }

  listenToClick(element): void {
    fromEvent(element, 'click').pipe(debounceTime(250), takeUntil(this._unsubscribeAll)).subscribe(close => {
      return this._matDialogRef?.close();
    });
  }

  ngOnDestroy(): void {
    this._unsubscribeAll.next(null);
    this.deviceView$.complete();
    this._unsubscribeAll.complete();
  }

  @Input('appCloseDialog')
  set appCloseDialog(dialogForm: FormGroup | undefined) {
    this._dialogForm = dialogForm;
  }
}
