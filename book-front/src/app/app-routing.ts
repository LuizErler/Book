import { Routes } from '@angular/router';
import { LivroComponent } from './livro/livro.component';
import { AutorComponent } from './autor/autor.component';
import { AssuntoComponent } from './assunto/assunto.component';

export const appRoutes: Routes = [
  { path: 'livro', component: LivroComponent },
  { path: 'autor', component: AutorComponent },
  { path: 'assunto', component: AssuntoComponent },
  { path: '', redirectTo: '/livro', pathMatch: 'full' } // Redireciona para /livro por padrão
];
