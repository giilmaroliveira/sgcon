import { BaseModel } from './base.model';

export class TowerModel  extends BaseModel {
    id: number;
    block: string;
    floorsNumber: number;
    condominiumId: number;
    quantityByFloor: number;
    floor: number;
}
