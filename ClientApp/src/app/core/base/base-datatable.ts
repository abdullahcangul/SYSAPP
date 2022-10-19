import { NgxSpinnerService } from "ngx-spinner";
import { DropDownButtonEnum } from "../enums/DropDownButtonEnum";
import { ViewTypeEnum } from "../enums/view-type.enum";
import { DropdownButtonModel } from "../models/dropdown-button.model";
import { AlertService } from "../services/alert.service";
import { BaseHttpService } from "../services/base-http.service";
import { HttpService } from "../services/http.service";

export abstract class BaseDatatable {
  ViewMode: ViewTypeEnum = ViewTypeEnum.LIST;
  public ViewType = ViewTypeEnum;
  row: any;
  columns: any[];
  rows: any[];
  protected controller:string;
  constructor(
    protected alert: AlertService,
    protected spinner: NgxSpinnerService,
    protected httpBaseService: BaseHttpService,
  ) {
  }

  async initDataTable() {
    await this.loadData();
    await this.loadColumns();
  }

  async loadData() {}
  abstract loadColumns();

  async delete() {
    const result = await this.alert.delete();

    if (result.isConfirmed) {
      this.spinner.show();
      console.log(this.controller)
      await this.httpBaseService.delete(this.controller,this.row.id).subscribe((p) => {
        this.spinner.hide();
        this.alert.ShowWarningTopRight();
      });
    }
  }

  async dropDownButtonClicked(model: DropdownButtonModel) {
    if (model) {
      this.row = model.row;
      this.ViewMode = this.convertDropdownToViewType(model.dropDownButtonEnum);
      this.checkIfViewModeDeleteAndDelete();
    }
  }
  checkIfViewModeDeleteAndDelete() {
    if (this.ViewMode == ViewTypeEnum.DELETE) {
      this.delete();
    }
  }

  convertDropdownToViewType(
    dropDownButtonEnum: DropDownButtonEnum
  ): ViewTypeEnum {
    let result;
    switch (dropDownButtonEnum) {
      case DropDownButtonEnum.DELETE:
        result = ViewTypeEnum.DELETE;
        break;
      case DropDownButtonEnum.ADD:
        result = ViewTypeEnum.ADD;
        break;
      case DropDownButtonEnum.UPDATE:
        result = ViewTypeEnum.UPDATE;
        break;
      case DropDownButtonEnum.DETAIL:
        result = ViewTypeEnum.DETAIL;
        break;

      default:
        result = ViewTypeEnum.LIST;
        break;
    }

    return result;
  }
}
