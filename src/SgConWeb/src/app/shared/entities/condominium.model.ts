import { BaseModel } from './base.model';

export class CondominiumModel extends BaseModel {
    name: string;
    cnpj: string;
    email: string;
    dddComercialPhone: string;
    comercialPhone: string;
    dddCellPhone: string;
    cellPhone: string;
    towerNumber: number
    cep: string;
    street: string;
    number: number;
    complement: string;
    neighborhood: string;
    city: string;
    uf: string;
}
