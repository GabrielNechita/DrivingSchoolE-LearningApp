import { IUser } from './user.interface';
import { IInstructor } from './instructor.interface';
import { ICategory } from './category.interface';

export interface IDriver{
    id?: number;
    enrollmentDate: Date;
    category?: ICategory;
    user: IUser;
    instructor?: IInstructor;
    quizResults?: any[];
    hasQuizAccess?: boolean;
}