import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { NgModule, LOCALE_ID } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ScheduleRoutingModule } from './schedule.routing.module';

// components
import { ScheduleListComponent } from './schedule-list/schedule-list.component';
import { ScheduleEditComponent } from './schedule-edit/schedule-edit.component';
import { ScheduleComponent } from './schedule.component';

// services
import { CommonAreaService } from '../../shared/services/commonarea.service';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ScheduleRoutingModule,
        NgbModule.forRoot(),
    ],
    exports: [],
    declarations: [
        ScheduleComponent,
        ScheduleEditComponent,
        ScheduleListComponent,
    ],
    providers: [
        CommonAreaService,
        { provide: LOCALE_ID, useValue: 'pt-Br' },
    ],
})
export class ScheduleModule { }
