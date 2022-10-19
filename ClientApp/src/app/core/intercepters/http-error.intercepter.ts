import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { NgxSpinnerService } from "ngx-spinner";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { AlertService } from "../services/alert.service";

@Injectable({
    providedIn: 'root'
  })
export class HttpErrorIntercepter implements HttpInterceptor{
    constructor(
        private alert:AlertService,
        private spinner:NgxSpinnerService,
        @Inject("baseUrl") private baseUrl: string) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req)
            .pipe(catchError(err=>{
                this.alert.error(err.message);
                this.spinner.hide();
                return of(err);
            }));
            
    }

}