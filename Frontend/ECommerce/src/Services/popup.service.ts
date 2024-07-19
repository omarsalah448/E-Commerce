import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

@Injectable({
  providedIn: 'root'
})
export class PopupService {

  constructor(private toastr: ToastrService) { }
  showSuccess(message: string, title: string){
    this.toastr.success(message, title);
  }      
  showError(message: string, title: string){
      this.toastr.error(message, title);
} 
}
