import { Note } from './note';

export class Book {
  public title: string;
  public slug: string;
  public description: string;
  public createdAt: Date;
  public updatedAt: Date;
  public author: string;

  public notes: Note[];
}
