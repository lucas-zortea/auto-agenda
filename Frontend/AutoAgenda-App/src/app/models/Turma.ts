import { Evento } from './Evento';
import { Disciplinas } from './Disciplinas';
export interface Turma {
  id: number;
  nome: string;
  datainicio: string;
  datafim: string;
  numeroalunos: number;
  Disciplinas: Disciplinas;
  Evento: Evento;
}
