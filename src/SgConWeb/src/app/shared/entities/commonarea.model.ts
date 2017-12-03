import { BaseModel } from './base.model';

export class CommonAreaModel  extends BaseModel {
    name: string;
    description: string;
    capacity: string;
    condominiumId: number;
}
