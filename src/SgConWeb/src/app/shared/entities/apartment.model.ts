import { BaseModel } from './base.model';

export class ApartmentModel extends BaseModel {
    number: number;
    floor: number;
    towerId: number;
    condominiumId: number;
}
