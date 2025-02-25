import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Importe os componentes que você vai usar nas rotas
import { MenuCadastrosComponent } from './menu-cadastros/menu-cadastros.component';
import { LivroComponent } from './livro/livro.component';
import { AutorComponent } from './autor/autor.component';
import { AssuntoComponent } from './assunto/assunto.component';

const routes: Routes = [
  { path: '', component: MenuCadastrosComponent },  // Página inicial com o menu
  { path: 'livro', component: LivroComponent },  // Componente de Livro
  { path: 'autor', component: AutorComponent },  // Componente de Autor
  { path: 'assunto', component: AssuntoComponent },  // Componente de Assunto
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
