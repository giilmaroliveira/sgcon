import { Component, OnInit } from "@angular/core";
// services
import { CondominiumService } from "../../../shared/services/condominium.service";
// moduls
import { CondominiumModel } from "../../../shared/entities/condominium.model";

@Component({
  selector: "app-condominium-list",
  templateUrl: "./condominium-list.component.html",
  styleUrls: ["./condominium-list.component.scss"]
})
export class CondominiumListComponent implements OnInit {
  condominiumList: CondominiumModel[] = new Array<CondominiumModel>();

  constructor(private _condominiumService: CondominiumService) {}

  ngOnInit() {
    this.getAllCondominium();
  }

  getAllCondominium() {
    this._condominiumService.getAllCondominium().subscribe(
      response => {
        this.condominiumList = response;
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }
}
