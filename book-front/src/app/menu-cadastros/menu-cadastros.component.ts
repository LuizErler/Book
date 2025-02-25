import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu-cadastros',
  imports: [],
  templateUrl: './menu-cadastros.component.html',
  styleUrl: './menu-cadastros.component.css'
})
export class MenuCadastrosComponent {
  constructor(private router: Router) {}

  public navegarParaLivro() {
    this.router.navigate(['/livro']);
  }
  public navegarParaAutor() {
    this.router.navigate(['/autor']);
  }
  public navegarParaAssunto() {
    this.router.navigate(['/assunto']);
  }
}

