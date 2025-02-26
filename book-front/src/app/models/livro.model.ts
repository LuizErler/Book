export interface Livro {
  codl: number;  // ID do livro
  titulo: string;  // Título do livro
  editora?: string;  // Nome da editora
  edicao?: number;  // Número da edição
  anoPublicacao?: string;  // Ano de publicação
  valor: number;  // Preço do livro
  autorId: number;  // ID do autor relacionado
  assuntoId: number;  // ID do assunto relacionado
}
