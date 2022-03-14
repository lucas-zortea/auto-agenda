import { Evento } from './Evento';
import { Disciplinas } from './Disciplinas';

export interface Instrutores {
  id: number;
  nome: string;
  apelido: string;
  email: string;
  disponivel: boolean;
  pilarID: number;
  pilar: number;
  Disciplinas: Disciplinas;
  Evento: Evento;
}
