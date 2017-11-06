import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../../router.animations';

@Component({
    selector: 'app-condominio-component',
    templateUrl: './condominio.component.html',
    //styleUrls: ['./condominio.component.scss'],
    animations: [routerTransition()]
})
export class CondominioListComponent implements OnInit {

    constructor() { }

    ngOnInit() { }
}
