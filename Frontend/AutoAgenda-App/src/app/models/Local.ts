import { Evento } from './Evento';

export interface Local {
  id: number
  nome: string
  slug: string
  informatizada: boolean
  capacidade: number
  evento: Evento[]
}
