import { Component } from '@angular/core';
import { AutorService } from './autor.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Autor } from '../models/autor.model';

@Component({
  selector: 'app-autor',
  standalone: true,
  imports: [HttpClientModule, CommonModule,FormsModule],
  providers:[AutorService],
  templateUrl: './autor.component.html',
  styleUrl: './autor.component.css'
})
export class AutorComponent {
autor: Autor = {
    codAu: 0,  // Ou qualquer valor padrão que você queira
    nome: ''
  };

  constructor(private autorService: AutorService) {}

   onSubmit(form: NgForm): void {
      if (form.valid) {
        this.autorService.addAutor(this.autor).subscribe(
          (response) => {
            alert('Autor cadastrado com sucesso!');
            form.reset();  // Resetando o formulário após envio
          },
          (error) => {
            alert('Erro ao cadastrar autor.');
            console.error(error);
          }
        );
      }
    }
}
