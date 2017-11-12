import { Component, Input, OnInit } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";

export interface ModalModel {
  title:string;
  message:string;
}

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent extends DialogComponent<ModalModel, boolean> implements ModalModel, OnInit {

  title: string;
  message: string;

  constructor(dialogService: DialogService) {
    super(dialogService);
  }

  ngOnInit() {
    
  }
  
  confirm() {

    this.result = true;
    this.close();
  }



}
