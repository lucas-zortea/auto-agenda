import { Local } from './Local';

export interface Evento {
  id: number
  nome: string
  slug: string
  dataInicio: Date
  dataFim: Date
  horaInicio: Date
  horaFim: Date

  local: Local
}
