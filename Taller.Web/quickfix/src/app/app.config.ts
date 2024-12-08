import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { RequestsInterceptor } from './interceptors/request.interceptor';
import { provideAnimations } from '@angular/platform-browser/animations/'
import { provideToastr } from 'ngx-toastr';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),

    provideHttpClient(
      withInterceptorsFromDi()
      ),
    //REGISTRAMOS todos los interceptores
      {
        //espeficamos que tendremos un servicio provedor que sera un interceptador
        provide: HTTP_INTERCEPTORS,
        //El interceptor que utilizaremos, automaticamente ejecutara la funcion de intercept
        useClass: RequestsInterceptor,
        multi:true // especifica que podremos tener varios interceptores en este caso solo teneemos uno
      }, provideAnimationsAsync(),
  
  ]
};
