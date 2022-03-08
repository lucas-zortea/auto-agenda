import { Evento } from './Evento';

export interface Disciplinas {
  id: number;
  nome: string;
  slug: string;

  evento: Evento[]

  // importar os modelos de turmas, instrutores e area
}
