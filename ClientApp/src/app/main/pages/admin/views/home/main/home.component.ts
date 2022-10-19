import { Component, OnInit, TemplateRef, ViewChild } from "@angular/core";
import { BaseDatatable } from "app/core/base/base-datatable";
import { ViewTypeEnum } from "app/core/enums/view-type.enum";
import { AlertService } from "app/core/services/alert.service";
import { BaseHttpService } from "app/core/services/base-http.service";
import { HttpService } from "app/core/services/http.service";
import {  NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
  
})
export class HomeComponent extends BaseDatatable implements OnInit {

  @ViewChild("statusTemplate", { static: true })
  statusCellTemplate: TemplateRef<any>;

  constructor(
    protected alert: AlertService,
    protected spinner:NgxSpinnerService,
    protected httpBaseService:BaseHttpService
    ) {
    super(alert,spinner,httpBaseService);
    this.controller="homes";
  }

  ngOnInit(): void {
    super.initDataTable();
  }

  async loadData() {
    this.rows = [
      { id: 1, name: "Maltepe",address:"Maltepe istanbul", color: "Red",status:1},
      { id: 2, name: "Kartal",address:"Kartal istanbul", color: "Yellow",status:2},
      { id: 3, name: "Pendik",address:"Pendik istanbul", color: "Red",status:3},
      { id: 4, name: "Tuzla",address:"Tuzla istanbul", color: "Yellow",status:4},
      { id: 5, name: "Bostancı",address:"Maltepe istanbul", color: "Red",status:1},
      { id: 6, name: "Kadıköy",address:"Kartal istanbul", color: "Yellow",status:1},
      { id: 7, name: "Umraniye",address:"Pendik istanbul", color: "Red",status:3},
      { id: 8, name: "Ortaköy",address:"Tuzla istanbul", color: "Yellow",status:3},
      { id: 9, name: "Eminönü",address:"Kartal istanbul", color: "Yellow",status:4},
      { id: 10, name: "Fatih",address:"Pendik istanbul", color: "Red",status:5},
      { id: 11, name: "Taksim",address:"Tuzla istanbul", color: "Yellow",status:2},
    ];
  }

  async loadColumns() {
    this.columns = [
      { prop: "id", name: "id" },
      { prop: "name", name: "name" },
      { prop: "address", name: "address" },
      { prop: "color", name: "color"},
      { prop: "status", name: "status",cellTemplate:this.statusCellTemplate},
      { prop: "actions", name: "actions"},
    ];
  }

  async back(){
    this.ViewMode=ViewTypeEnum.LIST;
  }
}
