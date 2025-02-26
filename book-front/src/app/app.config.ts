import { importProvidersFrom } from '@angular/core';
import { RouterModule } from '@angular/router';
import { appRoutes } from './app-routing';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

export const appConfig = {
  providers: [
    importProvidersFrom(RouterModule.forRoot(appRoutes)), provideAnimationsAsync(), provideAnimationsAsync()
  ]
};
