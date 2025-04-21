import { inject } from '@angular/core';
import {
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
  ResolveFn
} from '@angular/router';
import { Store } from '@ngrx/store';

export const ClearStateResolver: ResolveFn<void> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot,
  entityStateService: Store = inject(Store)
): void => {
  switch (route.data['entityType']) {

  }
}
