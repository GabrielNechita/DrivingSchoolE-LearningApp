import { ICategory } from './category.interface';
import { IAnswer } from './answer.interface';

export interface IQuestion{
    id?: number;
    value: string;
    difficulty: string;
    category?: ICategory;
    categoryId: number,
    answers: IAnswer[];
    image: string;
}