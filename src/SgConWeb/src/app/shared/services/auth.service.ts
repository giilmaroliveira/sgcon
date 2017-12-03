import { Injectable, EventEmitter } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { User } from '../../shared/entities/user.model';


@Injectable()
export class AuthService {
    private userAuthenticated: boolean = false;
    private returnUrl: string = null;

    constructor(private route: ActivatedRoute, private router: Router) { }

    employeeLogin(user: User) {

        user.typeUser = "Employee";
        this.buildLoginParams(user);

        this.route.queryParams.subscribe(params => {
            this.returnUrl = params["returnUrl"];
        });

        if (this.returnUrl) {
            this.router.navigate([this.returnUrl]);
            return;
        }

        this.router.navigate(["condominium/condominiumList"]);
    }

    residentLogin(user: User) {

        user.typeUser = "Resident";
        this.buildLoginParams(user);

        this.route.queryParams.subscribe(params => {
            this.returnUrl = params["returnUrl"];
        });

        if (this.returnUrl) {
            this.router.navigate([this.returnUrl]);
            return;
        }

        this.router.navigate(["dashboard"]);
    }

    userIsAuthenticated() {
        return this.userAuthenticated;
    }

    buildLoginParams(user: User) {
        localStorage.setItem("token", user.token);
        localStorage.setItem("typeUser", user.typeUser);
        localStorage.setItem('isLoggedin', 'true');
        this.userAuthenticated = true;
        //this.showMenuEmitter.emit(true);
    }

    logout() {
        let typeUser = localStorage.getItem("typeUser");
        if (typeUser == "Employee") {
            this.router.navigate(["/"]);
        } else {
            this.router.navigate(["resident/login"]);
        }
        localStorage.removeItem("typeUser");
        localStorage.removeItem("token");
    }
}