import { BaseModel } from './base.model';
import { Role } from './role.model';
import { ProfilePolicy } from './profile-policy.model';
import { Policy } from './policy.model';

export class Profile {
    name: string;
    description: string;
    roleId: number;
    role: Role;
    profilePolicies: ProfilePolicy;
    policies: Policy;
}