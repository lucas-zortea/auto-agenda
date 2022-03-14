import { Areas } from './Areas';
import { Instrutores } from './instrutores';
import { Turma } from './Turma';

import { Evento } from './Evento';

export interface Disciplinas {
  id: number;
  nome: string;
  slug: string;

  evento: Evento[];
  Turma: Turma;
  Instrutores: Instrutores;
  Areas: Areas;

  // importar os modelos de turmas, instrutores e area
}
