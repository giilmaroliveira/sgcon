import { BaseModel } from './base.model';

export class TowerModel  extends BaseModel {
    id: number;
    block: string;
    apartmentNumber: number;
    condominiumId: number;
}
