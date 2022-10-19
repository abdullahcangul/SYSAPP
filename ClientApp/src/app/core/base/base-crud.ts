import {
  Component,
  EventEmitter,
  Injectable,
  Input,
  Output,
} from "@angular/core";
import { FormGroup } from "@angular/forms";
import { ViewTypeEnum } from "../enums/view-type.enum";

@Component({
  template: "",
})
export abstract class BaseCrud {
  @Input() viewMode: ViewTypeEnum;
  @Input() row: any;
  @Output() backOnClick = new EventEmitter();

  public ReactiveForm: FormGroup;
  public ReactiveSubmitted = false;

  constructor() {}

  async load() {
    await this.initForm();
  }

  async initForm() {
    if (this.viewMode == ViewTypeEnum.ADD) {
      await this.loadAddForm();
    } else if (
      this.viewMode == ViewTypeEnum.UPDATE ||
      this.viewMode == ViewTypeEnum.DETAIL
    ) {
      await this.loadUpdateForm();
    }
  }

  convertFormDataToModel() {
    return Object.assign({}, this.ReactiveForm.value);
  }

  abstract loadAddForm(): void;
  abstract loadUpdateForm(): void;

  get _ReactiveForm() {
    return this.ReactiveForm.controls;
  }

  get isReadonly() {
    return ViewTypeEnum.DETAIL == this.viewMode;
  }

  get isInValidForm() {
    return this.ReactiveForm.invalid || this.isReadonly;
  }
}
