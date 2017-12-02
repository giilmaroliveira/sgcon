import { BaseModel } from './base.model';

export class Address extends BaseModel {

    addressTypeId: number;
    cep: string;
    street: string;
    number: number;
    complement: string;
    neighborhood: string;
    city: string;
    uf: string;
}