import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Disciplinas } from './../../models/Disciplinas';
import { DisciplinaService } from './../../services/disciplina.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-disciplinas',
  templateUrl: './disciplinas.component.html',
  styleUrls: ['./disciplinas.component.css']
})
export class DisciplinasComponent implements OnInit {

  modalRef?: BsModalRef;

  public disciplinas: Disciplinas[] = [];
  public disciplinasFiltradas: Disciplinas[] = [];

  private _filtroLista: string = '';

  public form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }

  constructor(
    private disciplinaService: DisciplinaService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private fb: FormBuilder
  ) {}

  public ngOnInit() {
    this.spinner.show();
    this.getDisciplinas();
    this.validation();
  }

  public validation(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      area: [Validators.required]
    });
  }

  public getDisciplinas(): void {
    this.disciplinaService.getDisciplinas().subscribe(
      (_disciplinas: Disciplinas[]) => {
        this.disciplinas = _disciplinas;
        this.disciplinasFiltradas = this.disciplinas;
      },
      (error) => {
        console.log(error);
        this.spinner.hide();
        this.toastr.error('Erro ao carregar o conteúdo', 'Erro!');
      },
      () => this.spinner.hide()
    );
  }

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.disciplinasFiltradas = this.filtroLista
      ? this.filtrarDisciplinas(this.filtroLista)
      : this.disciplinas;
  }

  public filtrarDisciplinas(filtrarPor: string): Disciplinas[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.disciplinas.filter(
      (disciplina: any) => disciplina.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Disciplina deletada com sucesso', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
