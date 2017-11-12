import { Component, OnInit } from '@angular/core';
import { CondominiumService } from '../../../shared/services/condominium.service';

@Component({
  selector: 'app-condominium-list',
  templateUrl: './condominium-list.component.html',
  styleUrls: ['./condominium-list.component.scss']
})
export class CondominiumListComponent implements OnInit {

  constructor(
    private _condominiumService: CondominiumService
  ) { }

  ngOnInit() {
          this.getAllCondominium();
  }

  getAllCondominium() {

    this._condominiumService.getAllCondominium()
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
      });
  }

}
