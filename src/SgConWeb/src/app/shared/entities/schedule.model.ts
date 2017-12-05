import { BaseModel } from './base.model';
import { CommonAreaModel } from './commonarea.model';

export class ScheduleModel  extends BaseModel {
    apartmentId: number;
    commonAreaId: number;
    date: Date;
    // startTime: number;
    // endTime: number;
    scheduleId: number;
    used: boolean;

    commonArea: CommonAreaModel;
}
