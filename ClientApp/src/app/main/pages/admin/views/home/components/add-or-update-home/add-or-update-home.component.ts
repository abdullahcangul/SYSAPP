import {
  Component,
  OnInit,
} from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { BaseCrud } from "app/core/base/base-crud";
import { AlertService } from "app/core/services/alert.service";
import { HttpService } from "app/core/services/http.service";
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: "app-add-or-update-home",
  templateUrl: "./add-or-update-home.component.html",
  styleUrls: ["./add-or-update-home.component.scss"],
})
export class AddOrUpdateHomeComponent extends BaseCrud implements OnInit {
  public basicPwdShow = false;
  public mergedPwdShow = false;

  constructor(
    private formBuilder: FormBuilder,
    private alert: AlertService,
    private spinner: NgxSpinnerService,
    private httpService: HttpService
  ) {
    super();
  }

  ngOnInit(): void {
    super.load();
  }

  async loadAddForm() {
    this.loadValidationForm();
  }

  async loadUpdateForm() {
    this.loadValidationForm();
    this.ReactiveForm.patchValue({ ...this.row });
  }

  loadValidationForm(){
    this.ReactiveForm = this.formBuilder.group({
      name: ["", [Validators.required, Validators.maxLength(50)]],
      address: ["", [Validators.required, Validators.maxLength(200)]],
    });
  }

  async ReactiveFormOnSubmit() {
    this.ReactiveSubmitted = true;
    // stop here if form is invalid or View Type Detail
    if(this.isInValidForm) return;

    const model = this.convertFormDataToModel();
    var result = await this.alert.save("Kaydet", "Kaydetmek ister misiniz ?");

    if (result.isConfirmed) {
      this.spinner.show();
      this.httpService.post(
        {
          controller: "homes",
          action: "Add",
        },
        model
      )
      .subscribe(p=>{
        this.spinner.hide();
        this.alert.ShowWarningTopRight();
      });
    }
  }

  async back(){
    this.backOnClick.emit();
  }
}
