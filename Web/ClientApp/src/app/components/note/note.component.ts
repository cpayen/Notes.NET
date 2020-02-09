import { Component, OnInit, OnDestroy } from '@angular/core';
import { Note } from 'src/app/models/note';
import { Subscription, PartialObserver } from 'rxjs';
import { ContentService } from '../../services/content.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Book } from 'src/app/models/book';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit, OnDestroy {
  book: Book;
  note: Note;

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
    this.contentService.GetBook(bookSlug).subscribe(o => this.book = o, o => console.error(o));
    this.contentService.GetNote(bookSlug, noteSlug).subscribe(o => this.note = o, o => console.error(o));
  }

}
