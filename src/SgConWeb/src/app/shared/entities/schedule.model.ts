import { BaseModel } from './base.model';

export class ScheduleModel  extends BaseModel {
    apartmentId: number;
    commonareaId: number;
    date: Date;
    time: number;
    // startTime: number;
    // endTime: number;
}
