export interface Livro {
  codl: number;  
  titulo: string;  
  editora?: string;  
  edicao?: number;  
  anoPublicacao: string;  
  valor: number;  
  autorIds: number[];  
  assuntoIds: number[];
  idsAutores?: string;
  idsAssuntos?: string;
}

