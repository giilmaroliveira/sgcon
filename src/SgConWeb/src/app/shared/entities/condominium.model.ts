import { BaseModel } from './base.model';
import { Address } from './address.model';

export class CondominiumModel extends BaseModel {

    name: string;
    cnpj: string;
    email: string;
    dddComercialPhone: string;
    comercialPhone: string;
    dddCellPhone: string;
    cellPhone: string;
    towerNumber: number;
    addressId: number;
    address: Address;
}
