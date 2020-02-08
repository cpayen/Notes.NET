import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// import { map } from 'rxjs/operators';
import { Book } from '../models/book';
import { Note } from '../models/note';

@Injectable({
  providedIn: 'root'
})
export class ContentService {
  constructor(
    private http: HttpClient
  ) { }

  GetBooks(): Observable<Book[]> {
    // return this.http.get('/api/content/books')
    // .pipe(
    //   map(o => o)
    // );
    return this.http.get<Book[]>('/api/content/books');
  }

  GetBook(bookSlug: string): Observable<Book> {
    return this.http.get<Book>(`/api/content/${bookSlug}`);
  }

  GetNote(bookSlug: string, noteSlug: string): Observable<Note> {
    return this.http.get<Note>(`/api/content/${bookSlug}/${noteSlug}`);
  }
}
