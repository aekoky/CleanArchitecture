import { AfterViewInit, Directive, ElementRef, Host, OnDestroy } from '@angular/core';
import { DatatableComponent, ColumnMode } from '@swimlane/ngx-datatable';

@Directive({
  selector: '[appResizeWatcher]',
  standalone: false
})
export class ResizeWatcherDirective implements AfterViewInit, OnDestroy {
  resizeObserver: ResizeObserver;

  constructor(
    private elementRef: ElementRef<HTMLElement>,
    private table: DatatableComponent,
  ) { }

  ngAfterViewInit(): void {
    this.resizeObserver = new ResizeObserver(entries => {
      this.table.recalculate();
    });
    this.resizeObserver.observe(this.elementRef.nativeElement);
  }

  ngOnDestroy(): void {
    this.resizeObserver.unobserve(this.elementRef.nativeElement);
  }
}
