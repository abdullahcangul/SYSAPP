import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor() { }

  async save(title:string,text:string){
    return await Swal.fire({
      title:title,
      text:text,
      icon:"question",
      showCancelButton:true
    })
  }
  async error(text:string){
    return await Swal.fire({
      title:"Hata Oluştu",
      text:text,
      icon:"error",
      
    })
  }

  async delete(){
    return await Swal.fire({
      title:"Silmek İstermisiniz?",
      text:"Silmek istediğinize emin misiniz",
      icon:"warning",
      showCancelButton:true
    })
  }

  async ShowWarningTopRight(){
    return await Swal.fire({
      title:"Kaydet",
      text:'Değişiklik kaydedildi',
      icon:"success",
      showConfirmButton:false,
      timer:1500,
      position:'bottom-end'
    });
  }
}
