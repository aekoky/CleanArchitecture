import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideServiceWorker } from '@angular/service-worker';
import { provideStore } from '@ngrx/store';
import { provideHttpClient } from '@angular/common/http';
import { API_BASE_URL } from './web-api-client';
import { problemCatalogReducer, problemCategoryReducer, problemReducer, problemsFilterReducer, problemsReducer } from './pages/problems/state-management/problems.reducer';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideServiceWorker('ngsw-worker.js', {
      enabled: !isDevMode(),
      registrationStrategy: 'registerWhenStable:30000'
    }),
    provideStore({ problems: problemsReducer, problemsFilter: problemsFilterReducer, problem: problemReducer, problemCatalog: problemCatalogReducer, problemCategory: problemCategoryReducer }),
    {
      provide: API_BASE_URL,
      useValue: "/api"
    },
    provideHttpClient()
  ]
};
