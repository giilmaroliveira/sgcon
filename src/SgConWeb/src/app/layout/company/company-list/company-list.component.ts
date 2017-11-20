import { CompanyModel } from './../../../shared/entities/company.model';
import { CompanyService } from './../../../shared/services/company.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.scss']
})
export class CompanyListComponent implements OnInit {

  companyList: CompanyModel[] = new Array<CompanyModel>();

    constructor(private _companyList: CompanyService) {}

    ngOnInit() {
      this.getAllCondominium();
    }

    getAllCondominium() {
      this._companyList.getAllCompany().subscribe(
        response => {
          this.companyList = response;
        },
        error => {
          console.log(error);
        }
      );
    }
  }
