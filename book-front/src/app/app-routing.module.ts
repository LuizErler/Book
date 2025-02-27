import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MenuCadastrosComponent } from './menu-cadastros/menu-cadastros.component';
import { LivroComponent } from './livro/livro.component';
import { AutorComponent } from './autor/autor.component';
import { AssuntoComponent } from './assunto/assunto.component';

const routes: Routes = [
  { path: '', component: MenuCadastrosComponent },  
  { path: 'livro', component: LivroComponent },  
  { path: 'autor', component: AutorComponent },  
  { path: 'assunto', component: AssuntoComponent },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
