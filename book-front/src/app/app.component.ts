import { Component } from '@angular/core';
import { MenuCadastrosComponent } from './menu-cadastros/menu-cadastros.component'; 
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true, 
  imports: [MenuCadastrosComponent, RouterOutlet], 
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'book-front';
}
