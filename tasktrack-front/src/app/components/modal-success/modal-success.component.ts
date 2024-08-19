import { Component } from '@angular/core';

@Component({
  selector: 'app-modal-success',
  templateUrl: './modal-success.component.html',
  styleUrls: ['./modal-success.component.css']
})
export class ModalSuccessComponent {
  isOpen: boolean = false;
  close() {
    this.isOpen = false
  }
}
