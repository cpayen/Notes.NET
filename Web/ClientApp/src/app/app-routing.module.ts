import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ContentComponent } from './components/content/content.component';
import { BookComponent } from './components/book/book.component';
import { NoteComponent } from './components/note/note.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'content', component: ContentComponent,
    children: [
      { path: ':bookSlug', component: BookComponent },
      { path: ':bookSlug/:noteSlug', component: NoteComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
