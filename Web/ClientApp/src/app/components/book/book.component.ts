import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Subscription, PartialObserver } from 'rxjs';
import { ContentService } from '../../services/content.service';
import { Book } from '../../models/book';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit, OnDestroy {
  // Data
  book: Book;
  // State
  loading: boolean;
  notFound: boolean;
  error: boolean;

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
    this.book = null;
    this.loading = true;
    this.notFound = false;
    this.error = false;

    this.contentService.GetBook(bookSlug).subscribe(o => this.handleSuccess(o), o => this.handleError(o));
  }

  handleSuccess(book: Book) {
    this.book = book;
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
