//import { UserMenu } from './userMenu';
//import { LoginResponse } from './loginResponse.model';
export class User {

    id: number;
	name: string;
    profile: string;
    roleId: string;
    profileId: number;
    userName: string;
    passWord: string;
    cpf: string;
    email: string;
    jobRole: string;
    expireAt?: Date;
    active: boolean;
    typeUser: string;
    updatedAt: Date;
    createdAt: Date;
    createdBy: string;
    UpdatedBy: string;
    token: string;
}