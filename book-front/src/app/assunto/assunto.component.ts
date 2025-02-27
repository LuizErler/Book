import { Component } from '@angular/core';
import { AssuntoService } from './assunto.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Assunto } from '../models/assunto.model';  // Importando a interface

@Component({
  selector: 'app-assunto',
  standalone: true,  
  imports: [HttpClientModule, CommonModule,FormsModule],  
  providers: [AssuntoService],
  templateUrl: './assunto.component.html',  
  styleUrls: ['./assunto.component.css']  
})
export class AssuntoComponent {


  assunto: Assunto = {
    codAs: 0,  
    descricao: ''
  };

  constructor(private assuntoService: AssuntoService) {}


  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.assuntoService.addAssunto(this.assunto).subscribe(
        (response) => {
          alert('Assunto cadastrado com sucesso!');
          form.reset();  
        },
        (error) => {
          alert('Erro ao cadastrar assunto.');
          console.error(error);
        }
      );
    }
  }
}
