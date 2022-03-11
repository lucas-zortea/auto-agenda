import { query } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css']
})
export class ProfessoresComponent implements OnInit {

  public professores: any = [];
  private _filtroLista: string = '';
  public professoresFiltrados: any = []
  public get filtroLista(){
    return this._filtroLista;
  }


  public set filtroLista(value:string){
    this._filtroLista = value;
    this.professoresFiltrados = this.filtroLista ? this.filtrarProfessor(this.filtroLista) : this.professores
  }

  public filtrarProfessor(filtrarPor: string) : any{
    filtrarPor = filtrarPor.toLowerCase();
    return this.professores.filter( //filtrando por nome e apelido
      (professor:any) => professor.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        professor.apelido.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        professor.email.toLocaleLowerCase().indexOf(filtrarPor) !== -1


      )
  }
  constructor(private http: HttpClient){ }

  ngOnInit(): void {
      this.getProfessores();

  }

  public getProfessores():void{
    this.http.get('https://localhost:7108/v1/instrutores').subscribe(
      response => {
        this.professores = response
        this.professoresFiltrados = this.professores;
      },
      error => console.log(error)
    )
  }


}
