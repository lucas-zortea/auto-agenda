import { Evento } from './Evento';
import { Disciplinas } from './Disciplinas';
import { Pilar } from './Pilar';
export interface Areas {
  id: Number,
  nome:string,
  Pilar:Pilar,
  Disciplinas:Disciplinas,
  Evento:Evento,
}
