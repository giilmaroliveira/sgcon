import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
    {
        path: '', component: LayoutComponent,
        children: [
            { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardModule' },
            { path: 'charts', loadChildren: './charts/charts.module#ChartsModule' },
            { path: 'tables', loadChildren: './tables/tables.module#TablesModule' },
            { path: 'forms', loadChildren: './form/form.module#FormModule' },
            { path: 'bs-element', loadChildren: './bs-element/bs-element.module#BsElementModule' },
            { path: 'grid', loadChildren: './grid/grid.module#GridModule' },
            { path: 'components', loadChildren: './bs-component/bs-component.module#BsComponentModule' },
            { path: 'blank-page', loadChildren: './blank-page/blank-page.module#BlankPageModule' },
            { path: 'condominio', loadChildren: './condominio/condominio.module#CondominioModule' },
            { path: 'condominium', loadChildren: './condominium/condominium.module#CondominiumModule' },
            { path: 'resident', loadChildren: './resident/resident.module#ResidentModule' },
            { path: 'employee', loadChildren: './employee/employee.module#EmployeeModule' },
            { path: 'notices', loadChildren: './notices/notices.module#NoticesModule' },
            { path: 'company', loadChildren: './company/company.module#CompanyModule' },
            { path: 'tower', loadChildren: './tower/tower.module#TowerModule' },
            { path: 'apartment', loadChildren: './apartment/apartment.module#ApartmentModule' },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutRoutingModule { }
