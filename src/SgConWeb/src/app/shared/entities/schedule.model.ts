import { BaseModel } from './base.model';

export class ScheduleModel  extends BaseModel {
    apartmentId: number;
    commonAreaId: number;
    date: Date;
    // startTime: number;
    // endTime: number;
    scheduleId: number;
    used: boolean;
}
