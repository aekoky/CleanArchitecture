import { Directive, ElementRef, HostListener, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Directive({
  selector: '[appScrollToInvalide]',
  standalone: false
})
export class ScrollToInvalideDirective {
  @Input() formGroup: FormGroup | null = null;

  constructor(private el: ElementRef,) {
  }

  static scrollToElement(element: HTMLElement) {
    if (element) {
      const distance = window.scrollY - Math.abs(element.getBoundingClientRect().y);
      let parent = ScrollToInvalideDirective.getScrollParent(element);
      if (!parent)
        return;
      parent.scroll({
        behavior: 'smooth',
        left: 0,
        top: element.getBoundingClientRect().top + parent.scrollTop - 150,
      });
      setTimeout(() => {
        element.focus();
        element.blur();
        element.focus();
      }, distance);
    }
  }

  static markFormGroupTouched(formGroup: FormGroup | null) {
    (<any>Object).values(formGroup?.controls).forEach((control: FormGroup) => {
      control.markAsTouched();

      if (control.controls) {
        ScrollToInvalideDirective.markFormGroupTouched(control);
      }
    });
  }

  static getScrollParent(element) {
    if (element == null) {
      return null;
    }

    if (element.scrollHeight > element.clientHeight) {
      return element;
    } else {
      return ScrollToInvalideDirective.getScrollParent(element.parentNode);
    }
  }

  @HostListener('submit', ['$event'])
  onSubmit(event: Event) {
    event.preventDefault();

    ScrollToInvalideDirective.markFormGroupTouched(this.formGroup);

    const formControlInvalid = this.el.nativeElement.querySelector('.ng-invalid');

    if (formControlInvalid) {
      return ScrollToInvalideDirective.scrollToElement(formControlInvalid);
    } else {
      // The first element is the global form and here we are looking for the first nested form
      const formGroupInvalid = this.el.nativeElement.querySelectorAll('form .ng-invalid, .mat-mdc-form-field-error');
      if (formGroupInvalid && formGroupInvalid.length) {
        return ScrollToInvalideDirective.scrollToElement(formGroupInvalid[0]);
      }
    }

    return ScrollToInvalideDirective.scrollToElement(this.el.nativeElement);
  }
}