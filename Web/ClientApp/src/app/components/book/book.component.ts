import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ContentService } from '../../services/content.service';
import { Book } from '../../models/book';
import { Subscription, PartialObserver } from 'rxjs';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit, OnDestroy {
  book: Book;

  private subscription: Subscription;
  private paramMapObserver: PartialObserver<ParamMap> = {
    next: paramMap => { this.loadBook(paramMap.get('bookSlug')); },
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

  loadBook(bookSlug: string) {
    this.contentService.GetBook(bookSlug).subscribe(o => this.book = o, o => console.error(o));
  }

}
