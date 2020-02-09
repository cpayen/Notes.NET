import { Component, OnInit, Input } from '@angular/core';
import { Book } from 'src/app/models/book';
import { Note } from 'src/app/models/note';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent implements OnInit {
  @Input() book: Book;
  @Input() note: Note;
  @Input() page: string;

  constructor() { }

  ngOnInit() {
  }

}
