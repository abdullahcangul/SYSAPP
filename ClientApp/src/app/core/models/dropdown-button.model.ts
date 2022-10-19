import { DropDownButtonEnum } from "../enums/DropDownButtonEnum";


export class DropdownButtonModel {
    dropDownButtonEnum:DropDownButtonEnum;
    row:any;
    constructor( dropDownButtonEnum:DropDownButtonEnum,row:any) {
        this.dropDownButtonEnum=dropDownButtonEnum;
        this.row=row;
    }
}