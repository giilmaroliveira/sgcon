import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NoticesComponent } from './notices.component';
import { NoticeRoutingModule } from './notices.routing.module';
import { NoticesListComponent } from './notices-list/notices-list.component';
import { NoticesEditComponent } from './notices-edit/notices-edit.component';

@NgModule({
    imports: [
        CommonModule,
        NoticeRoutingModule
    ],
    exports: [],
    declarations: [
        NoticesComponent,
        NoticesEditComponent,
        NoticesListComponent
    ],
    providers: [],
})
export class NoticesModule { }
