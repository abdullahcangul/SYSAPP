import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  TemplateRef,
  ViewChild,
  ViewEncapsulation,
} from "@angular/core";
import {
  ColumnMode,
  DatatableComponent,
  SelectionType,
} from "@swimlane/ngx-datatable";
import { DropDownButtonEnum } from "app/core/enums/DropDownButtonEnum";
import { DropdownButtonModel } from "app/core/models/dropdown-button.model";
import { Subject } from "rxjs";

@Component({
  selector: "ca-base-datatable",
  templateUrl: "./ca-datatable.component.html",
  styleUrls: ["./ca-datatable.component.scss"],
  encapsulation: ViewEncapsulation.None,
})
export class CaDatatableComponent implements OnInit {
  @ViewChild("moreCellTemplate", { static: true })
  moreCellTemplate: TemplateRef<any>;
  @ViewChild(DatatableComponent) table: DatatableComponent;
  @Output() dropDownButtonEmiter: EventEmitter<DropdownButtonModel> = new EventEmitter();
  // Private
  private _unsubscribeAll: Subject<any>;
  private tempData = [];
  public _columns= [];
  public _rows= [];

  // public
  public contentHeader: object;
  public selected = [];
  public tempRows: any;
  public basicSelectedOption: number = 10;
  public ColumnMode = ColumnMode;
  public DropDownButtonEnum = DropDownButtonEnum;
  public expanded = {};
  public chkBoxSelected = [];
  public SelectionType = SelectionType;
  public exportCSVData;

  //input-output
  @Input() set rows(value) {
    if (value) {
      this._rows = value;
      this.tempRows = [...this._rows];
      this.tempData = [...this._rows];
      this.exportCSVData = [...this._rows];
    }
  }
  @Input() set columns(value: any[]) {
    if (value != null) {
      const action = value.find((p) => p.name == "actions");
      if (action) action.cellTemplate = this.moreCellTemplate;
      this._columns = value;
    }
  }

  constructor(private cd: ChangeDetectorRef) {}
  /**
   * Method Search (filter)
   *
   * @param event
   */
  filterUpdate(event) {
    
    
    const val = event.target.value.toLowerCase();
    const columnsCount=this._columns.length-1;
    console.log(this._rows,this.tempData);
    
    // filter our data
      const temp = this.tempData.filter( (d,index1) =>{
   
        for (let index2 = 0; index2 < columnsCount; index2++) {
        
          if( this.tempData[index1][this._columns[index2].name].toString().toLowerCase().indexOf(val) !== -1 ){
            return true;
          }
        }
      });
  
      // update the rows
      //this.tempRows = [...temp];
     
    
    this._rows = [...temp];
    
    // Whenever the filter changes, always go back to the first page
    this.table.offset = 0;
  }

  /**
   * On init
   */
  ngOnInit() {}
  /**
   * For ref only, log selected values
   *
   * @param selected
   */
  onSelect({ selected }) {
    //console.log("Select Event", selected, this.selected);

    this.selected.splice(0, this.selected.length);
    this.selected.push(...selected);
  }

  /**
   * For ref only, log activate events
   *
   * @param selected
   */
  onActivate(event) {
   // console.log("Activate Event", event);
  }
  onMoreButonSelected(dropDownButtonEnum:DropDownButtonEnum,row:any) {
    const model=new DropdownButtonModel(dropDownButtonEnum,row);
    this.dropDownButtonEmiter.emit(model);
  }
  onAdd(){
    const model=new DropdownButtonModel(DropDownButtonEnum.ADD,0);
    this.dropDownButtonEmiter.emit(model);
  }
}
