import { Component, OnInit, TemplateRef } from '@angular/core';
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

  public locais: Local[] = [];
  public locaisFiltrados: Local[] = [];

  private _filtroLista: string = '';

  constructor(
    private localService: LocalService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  public ngOnInit() {
    this.spinner.show();
    this.getLocais();
  }
  public getLocais(): void {
    this.localService.getLocais().subscribe(
      (_locais: Local[]) => {
        this.locais = _locais
        this.locaisFiltrados = this.locais
      },
      error => {
        console.log(error);
        this.spinner.hide();
        this.toastr.error('Erro ao carregar o conteúdo', 'Erro!');
      },
      () => this.spinner.hide()
      );
    }

    public get filtroLista(): string{
      return this._filtroLista;
    }

    public set filtroLista(value: string){
      this._filtroLista = value;
      this.locaisFiltrados = this.filtroLista ? this.filtrarLocais(this.filtroLista) : this.locais;
    }

    public filtrarLocais(filtrarPor: string): Local[] {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.locais.filter(
        (local: any) => local.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    openModal(template: TemplateRef<any>): void {
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }

    confirm(): void {
      this.modalRef?.hide();
      this.toastr.success('O local foi deletado com sucesso', 'Deletado!');
    }

    decline(): void {
      this.modalRef?.hide();
    }
  }
