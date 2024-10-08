import { Component } from '@angular/core';

@Component({
  selector: 'app-modal-delete',
  templateUrl: './modal-delete.component.html',
  styleUrls: ['./modal-delete.component.css']
})
export class ModalDeleteComponent {
  isOpen: boolean = false;
  close() {
    this.isOpen = false;
  }
}
