import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideServiceWorker } from '@angular/service-worker';
import { provideStore } from '@ngrx/store';
import { problemPageStateReducer } from './pages/problems/state-management/problems.reducer';
import { provideHttpClient } from '@angular/common/http';
import { API_BASE_URL } from './web-api-client';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideServiceWorker('ngsw-worker.js', {
      enabled: !isDevMode(),
      registrationStrategy: 'registerWhenStable:30000'
    }),
    provideStore({ problemPageState: problemPageStateReducer }),
    {
      provide: API_BASE_URL,
      useValue: "/api"
    },
    provideHttpClient()
  ]
};
