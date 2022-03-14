import { Evento } from './Evento';

export interface Disciplinas {
  id: number;
  nome: string;
  slug: string;
  areaId: number;

  //area: Area[];
  //turma: Turma[];
  //instrutor: Instrutor[];
  evento: Evento[];

  // importar os modelos de turmas, instrutores e area
}
