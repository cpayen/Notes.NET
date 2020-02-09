import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Subscription, PartialObserver } from 'rxjs';
import { ContentService } from '../../services/content.service';
import { Note } from 'src/app/models/note';
import { Book } from 'src/app/models/book';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit, OnDestroy {
  // Data
  book: Book;
  note: Note;
  // State
  loading: boolean;
  notFound: boolean;
  error: boolean;

  private subscription: Subscription;
  private paramMapObserver: PartialObserver<ParamMap> = {
    next: paramMap => { this.loadNote(paramMap.get('bookSlug'), paramMap.get('noteSlug')); },
  };

  constructor(
    private contentService: ContentService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.subscription = this.route.paramMap.subscribe(this.paramMapObserver);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  loadNote(bookSlug: string, noteSlug: string) {
    this.book = null;
    this.loading = true;
    this.notFound = false;
    this.error = false;

    // TODO: properly handle multiple requests. ForkJoin?
    // https://coryrylan.com/blog/angular-multiple-http-requests-with-rxjs
    this.contentService.GetBook(bookSlug).subscribe(o => this.book = o, o => console.error(o));
    this.contentService.GetNote(bookSlug, noteSlug).subscribe(o => this.handleSuccess(o), o => this.handleError(o));
  }

  handleSuccess(note: Note) {
    this.note = note;
    this.loading = false;
  }

  handleError(error: any) {
    console.error(error);
    this.loading = false;
    switch (error.status) {
      case 404: this.notFound = true; break;
      default: this.error = true; break;
    }
  }

}
