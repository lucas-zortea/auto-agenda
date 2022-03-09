import { LocalComponent } from './components/local/local.component';
import { DisciplinasComponent } from './components/disciplinas/disciplinas.component';
import { InicialComponent } from './components/inicial/inicial.component';
import { TurmasComponent } from './components/turmas/turmas.component';
import { ProfessoresComponent } from './components/professores/professores.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'inicial', pathMatch: 'full' },
  { path: 'professores', component: ProfessoresComponent },
  { path: 'turmas', component: TurmasComponent },
  { path: 'inicial', component: InicialComponent },
  { path: 'disciplinas', component: DisciplinasComponent },
  { path: 'locais', component: LocalComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
