import { BaseModel } from './base.model';
import { TowerModel } from './tower.model';

export class ApartmentModel extends BaseModel {
    number: string;
    floor: string;
    towerId: number;
    // condominiumId: number;
    tower: TowerModel;
}
