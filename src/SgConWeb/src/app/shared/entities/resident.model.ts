import { BaseModel } from './base.model';

export class ResidentModel extends BaseModel {
    name: string;
    cpf: string;
    email: string;
    dddComercialPhone: string;
    comercialPhone: string;
    dddCellPhone: string;
    cellPhone: string;
    userName: string;
    passWord: string;
}
