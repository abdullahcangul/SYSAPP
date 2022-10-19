import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { HttpService } from "./http.service";

@Injectable({
    providedIn: 'root'
  })
export class BaseHttpService {
  protected action: string;
  protected controller: string;

  constructor(protected httpService: HttpService) {}

  get() {
    return this.httpService.get({
      controller: this.controller,
      action: "GetAll",
    },);
  }

  getById(id:any) {
    return this.httpService.get({
      controller: this.controller,
      action: "GetById",
    },id);
  }

  post(body: any) {
    return this.httpService.post(
      {
        controller: this.controller,
        action: "Add",
      },
      body
    );
  }

  put(body: any) {
    return this.httpService.put(
      {
        controller: this.controller,
        action: "Update",
      },
      body
    );
  }

  delete(controller:string,id: any) {
    return this.httpService.delete(
      {
        controller: controller,
      },
      id
    );
  }
}
