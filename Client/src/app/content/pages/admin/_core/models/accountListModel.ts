import { BaseModel } from './_base.model';
export class AccountListModel extends BaseModel {
    id: string;
    email: string;
    userName: string;
    role: string;
    active: boolean;
    latestLoginAt: string;
    lockoutEndAt: string;
    accessFailedCount: number;
    createdAt: string;
    updatedAt: string;
}



