import { Directive, OnDestroy, Optional, TemplateRef, ViewContainerRef } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { MatDialogRef } from "@angular/material/dialog";

@Directive({
  selector: '[appOnlyDialog]',
  standalone: false
})
export class OnlyDialogDirective implements OnDestroy {
  private readonly deviceView$ = new BehaviorSubject<boolean>(false);

  constructor(
    @Optional() _matDialogRef: MatDialogRef<any>,
    viewContainer: ViewContainerRef,
    templateRef: TemplateRef<any>
  ) {
    if (_matDialogRef) {
      viewContainer.createEmbeddedView(templateRef);
    } else
      viewContainer.clear();
  }

  ngOnDestroy(): void {
    this.deviceView$.complete();
  }
}
