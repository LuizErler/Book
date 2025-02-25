import { importProvidersFrom } from '@angular/core';
import { RouterModule } from '@angular/router';
import { appRoutes } from './app-routing';

export const appConfig = {
  providers: [
    importProvidersFrom(RouterModule.forRoot(appRoutes))
  ]
};
