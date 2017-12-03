import { Component, OnInit } from '@angular/core';

// Models
import { User } from '../../entities/user.model';

// Services
import { LoginService } from '../../services/login.service';
import { ShareObjectsService } from '../../services/share-objects.service';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
    isActive = false;
    showMenu = '';
    typeUser: string;
    user: User;

    constructor( 
        private _loginService: LoginService,
        private _shareObjectsService: ShareObjectsService
    ) 
    { }

    eventCalled() {
        this.isActive = !this.isActive;
    }

    addExpandClass(element: any) {
        if (element === this.showMenu) {
            this.showMenu = '0';
        } else {
            this.showMenu = element;
        }
    }

    ngOnInit() {

        this.typeUser = localStorage.getItem('typeUser');
        this.getUserInfo();
    }

    getUserInfo() {

        this._loginService.getUserMe(this.typeUser)
            .subscribe(response => {
                this.user = response;

                this._shareObjectsService.setUser(this.user);
                
            }, error => console.log(error));
    }
}
