import { BaseModel } from './base.model';

export class ApartmentModel extends BaseModel {
    number: string;
    floor: string;
    towerId: number;
    condominiumId: number;
}
