import { Component } from '@angular/core';
import { AssuntoService } from './assunto.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Assunto } from '../models/assunto.model';  // Importando a interface

@Component({
  selector: 'app-assunto',
  standalone: true,  // Marcando o componente como standalone
  imports: [HttpClientModule, CommonModule,FormsModule],  // Importando os módulos necessários
  providers: [AssuntoService],
  templateUrl: './assunto.component.html',  // Usando um template externo
  styleUrls: ['./assunto.component.css']  // Usando um arquivo de estilos externo
})
export class AssuntoComponent {

  // Inicializando o objeto diretamente com valores padrão
  assunto: Assunto = {
    codAs: 0,  // Ou qualquer valor padrão que você queira
    descricao: ''
  };

  constructor(private assuntoService: AssuntoService) {}

  // Função para o envio do formulário
  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.assuntoService.addAssunto(this.assunto).subscribe(
        (response) => {
          alert('Assunto cadastrado com sucesso!');
          form.reset();  // Resetando o formulário após envio
        },
        (error) => {
          alert('Erro ao cadastrar assunto.');
          console.error(error);
        }
      );
    }
  }
}
