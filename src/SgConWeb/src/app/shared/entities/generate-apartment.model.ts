import { BaseModel } from './base.model';

export class GenerateApartment extends BaseModel {
    quantityByFloor: number;
    floor: number;
    towerId: number;
    condominiumId: number;
}
