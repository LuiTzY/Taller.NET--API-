import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class RequestsInterceptor implements HttpInterceptor {

    constructor (){}

    //Funcion que nos permitira interceptar la request obtenida (es como un middleware que tendremos)
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
            const reqCloned = req.clone(
                {
                    headers:req.headers
                    //seteamos los encabezados del tipo de dato que nos devolvera la api y que el api espera
                    .set('Content-type','application/json')
                }
            )

        console.log(`Interpceptamos la request ${req.url}`)
        //si no hay un token aun asi se continuara con la solicitud de igual manera el backend lo validara
        return next.handle(req)
    }
}