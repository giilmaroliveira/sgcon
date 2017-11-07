import { Component, OnInit } from '@angular/core';
import { routerTransition } from 'app/router.animations';

@Component({
  selector: 'app-condominio-select',
  templateUrl: './condominio-select.component.html',
  //styleUrls: ['./condominio-select.component.scss'],
  animations: [routerTransition()]
})
export class CondominioSelectComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
