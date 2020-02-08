import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Book } from '../../models/book';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnInit {
  books: Book[];

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.GetContent().subscribe(o => this.books = o, o => console.error(o));
  }

  GetContent(): Observable<Book[]> {
    return this.http.get<Book[]>('/api/content/books');
  }

}
