import { NgModule, ErrorHandler, Input, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Http, HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthGuard } from './shared';
import { ModalComponent } from './shared/components/modal/modal.component';
import { AppErrorHandler } from './app.errorHandler';
import { BlockUIModule } from 'ng-block-ui';
// import { CondominioModule } from './condominio/condominio.module';
// AoT requires an exported function for factories

import { ApiRoutesService } from './shared/apiRoutes/apiRoutes.service';
import { HttpBaseService } from './shared/services/http-base.service';
import { DialogService } from 'ng2-bootstrap-modal';

export function HttpLoaderFactory(http: Http) {
    // for development
    // return new TranslateHttpLoader(http, '/start-angular/SB-Admin-BS4-Angular-4/master/dist/assets/i18n/', '.json');
    return new TranslateHttpLoader(http, '/assets/i18n/', '.json');
}
@NgModule({
    declarations: [
        AppComponent,
        ModalComponent
    ],
    imports: [BrowserModule,
        BrowserAnimationsModule,
        HttpModule,
        AppRoutingModule,
        BlockUIModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [Http]
            }
        })
    ],
    providers: [
        AuthGuard,
        ApiRoutesService,
        HttpBaseService,
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: LOCALE_ID, useValue: 'pt-Br' },
        DialogService
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}
