import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

// componetens
import { CommonareaComponent } from './commonarea.component';
import { CommonareaEditComponent } from './commonarea-edit/commonarea-edit.component';
import { CommonareaListComponent } from './commonarea-list/commonarea-list.component';
// routs
import { CommonareaRoutingModule } from './commonarea.routing.module';

// services
import { CondominiumService } from './../../shared/services/condominium.service';
import { CommonAreaService } from './../../shared/services/commonarea.service';

@NgModule({
    imports: [
        CommonModule,
        CommonareaRoutingModule,
        NgbModule.forRoot(),
        FormsModule,
        ReactiveFormsModule
    ],
    exports: [

    ],
    declarations: [
        CommonareaComponent,
        CommonareaEditComponent,
        CommonareaListComponent
    ],
    providers: [
        CommonAreaService,
        CondominiumService
    ],
})
export class CommonareaModule { }
