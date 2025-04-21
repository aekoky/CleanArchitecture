import { AfterViewInit, Directive, Host } from '@angular/core';
import { DatatableComponent, ColumnMode } from '@swimlane/ngx-datatable';

@Directive({
    selector: '[appColumnMode]',
    standalone: false
})
export class ColumnModeDirective implements AfterViewInit {

  constructor(@Host() private datatable: DatatableComponent) {
    this.datatable.columnMode = ColumnMode.flex;
  }
  
  ngAfterViewInit(): void {
    this.datatable.columnMode = ColumnMode.force;
  }
}
