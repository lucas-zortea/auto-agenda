import { Areas } from './Areas';
import { Instrutores } from './instrutores';
export interface Pilar {
  id: number;
  nome: string;
  cor: string;
  Instrutores: Instrutores;
  Areas: Areas;
  //areas
}
