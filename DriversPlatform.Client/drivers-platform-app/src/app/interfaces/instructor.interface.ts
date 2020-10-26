import { IUser } from './user.interface';
import { ICategory } from './category.interface';

export interface IInstructor{
    id?: number;
    hireDate: Date;
    salary: number;
    categories: ICategory[];
    user: IUser;
}