import { Turma } from './../../models/Turma';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LocalService } from 'src/app/services/local.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-turmas',
  templateUrl: './turmas.component.html',
  styleUrls: ['./turmas.component.css'],
})
export class TurmasComponent implements OnInit {
  turmaService: any;
  public get localService(): LocalService {
    return this._localService;
  }
  public set localService(value: LocalService) {
    this._localService = value;
  }
  modalRef?: BsModalRef;

  public locais: Turma[] = [];
  public locaisFiltrados: Turma[] = [];

  private _filtroLista: string = '';

  public form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private _localService: LocalService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private fb: FormBuilder
  ) {}

  public ngOnInit() {
    this.spinner.show();
    this.getLocais();
    this.validation();
  }

  public validation(): void {
    this.form = this.fb.group({
      nome: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(30),
        ],
      ],
      capacidade: [
        '',
        [Validators.required, Validators.min(1), Validators.max(150)],
      ],
      informatizada: [Validators.required],
    });
  }

  public getLocais(): any {
    this.turmaService.getTurma().subscribe({
      next: (_turmas: Turma[]) => {
        this.locais = _turmas;
        this.locaisFiltrados = this.locais;
      },
      error: (error: any) => {
        console.log(error);
        this.spinner.hide();
        this.toastr.error('Erro ao carregar o conteúdo', 'Erro!');
      },
      continue: () => this.spinner.hide(),
    });
  }

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.locaisFiltrados = this.filtroLista
      ? this.filtrarLocais(this.filtroLista)
      : this.locais;
  }

  public filtrarLocais(filtrarPor: string): Turma[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.locais.filter(
      (local: any) => local.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O local foi deletado com sucesso', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
