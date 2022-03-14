import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Local } from '../../models/Local';
import { LocalService } from '../../services/local.service';

@Component({
  selector: 'app-local',
  templateUrl: './local.component.html',
  styleUrls: ['./local.component.css'],
})
export class LocalComponent implements OnInit {
  modalRef?: BsModalRef;

  public local = {} as Local
  public locais: Local[] = [];
  public locaisFiltrados: Local[] = [];
  localId!: number;
  localNome!:string;
  localInformatizado!: boolean;
  localCapacidade!: number;

  estadoSalvar = 'post';

  private _filtroLista: string = '';

  public form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }

  constructor(
    private localService: LocalService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private fb: FormBuilder,
    private router: ActivatedRoute
  ) {}

  public carregarLocal(): void{
    const localIdParam = this.router.snapshot.paramMap.get('id');
    if(localIdParam !== null){
      this.localService.getLocalById(+localIdParam).subscribe({
        next: (local: Local) => {
          this.local = { ...local };
          this.form.patchValue(this.local);
        },
        error: (error: any) => {console.error(error)},
        complete: () => {}
      })
    }
  }

  public ngOnInit() {
    this.spinner.show();
    this.getLocais();
    this.validation();
    this.carregarLocal();
  }

  public validation(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      capacidade: ['', [Validators.required, Validators.min(1), Validators.max(150)]],
      informatizada: [Validators.required]
    });
  }

  public getLocais(): void {
    this.localService.getLocais().subscribe(
      (_locais: Local[]) => {
        this.locais = _locais;
        this.locaisFiltrados = this.locais;
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
    this.locaisFiltrados = this.filtroLista
      ? this.filtrarLocais(this.filtroLista)
      : this.locais;
  }

  public filtrarLocais(filtrarPor: string): Local[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.locais.filter(
      (local: any) => local.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  openModal(template: TemplateRef<any>, localId: number, localNome: string): void {
    this.localId = localId;
    this.localNome = localNome;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  openModal1(template: TemplateRef<any>): void {
    this.estadoSalvar = 'post'
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  openModal2(template: TemplateRef<any>, localId: number, localNome: string, localInformatizado: boolean, localCapacidade: number): void {
    this.estadoSalvar = 'put';
    console.log(this.estadoSalvar);
    this.localId = localId;
    this.localNome = localNome;
    this.localInformatizado = localInformatizado;
    this.localCapacidade = localCapacidade;

    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }


  confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();
    this.localService.deleteLocal(this.localId).subscribe(
      (result: any) => {
          this.toastr.success('O local foi deletado com sucesso', 'Deletado!');
          this.spinner.hide();
          this.getLocais();
      },
      (error: any) => {
        console.error(error);
        this.toastr.error(`Erro ao deletar o local ${this.localId}`);
        this.spinner.hide();

      },
      () => this.spinner.hide()
      )
  }

  decline(): void {
    this.modalRef?.hide();
  }

  public salvarAlteracao(): void{
    this.spinner.show();
    if(this.form.valid){
      if(this.estadoSalvar === 'post'){

        this.local = { ... this.form.value };
        this.localService.postLocal(this.local).subscribe(
          () => {
            this.toastr.success('Local salvo com sucesso', 'Sucesso');
            this.spinner.hide();
            this.getLocais();
          },
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar local', 'Erro');
          },
          () => this.spinner.hide()
        );
      }else{

        this.local = {id: this.localId, ... this.form.value };
        this.localService.putLocal(this.localId, this.local).subscribe(
          () => {
            this.toastr.success('Local salvo com sucesso', 'Sucesso');
            this.spinner.hide();
            this.getLocais();
          },
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar local', 'Erro');
          },
          () => this.spinner.hide()
        );
      }
    }
  }
}
