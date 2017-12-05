import { BaseModel } from './base.model';
import { CondominiumModel } from './condominium.model';

export class TowerModel  extends BaseModel {
    id: number;
    block: string;
    floorsNumber: number;
    condominiumId: number;

    condominium: CondominiumModel;
}
