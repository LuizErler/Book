import { Component } from '@angular/core';
import { MenuCadastrosComponent } from './menu-cadastros/menu-cadastros.component'; // Ajuste o caminho conforme necessário
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true, // Indica que o AppComponent é standalone
  imports: [MenuCadastrosComponent, RouterOutlet], // Certifique-se de incluir o MenuCadastros aqui
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'book-front';
}
