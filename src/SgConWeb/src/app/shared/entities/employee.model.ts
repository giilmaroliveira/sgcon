import { BaseModel } from './base.model';
import { Address } from './address.model';

export class EmployeeModel extends BaseModel {
    name: string;
    cpf: string;
    email: string;
    dddComercialPhone: string;
    comercialPhone: string;
    dddCellPhone: string;
    cellPhone: string;
    cep: string;
    street: string;
    number: number;
    complement: string;
    neighborhood: string;
    city: string;
    uf: string;
    addressId: number;
    address: Address;
}
