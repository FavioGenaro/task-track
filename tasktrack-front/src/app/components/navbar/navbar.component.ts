import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  isMenuOpen: boolean = false;
  animationState = 'closeMenu';

  constructor(private router: Router){

  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  @HostListener('document:click', ['$event'])
  onClick(event: MouseEvent) {
    const target = event.target as HTMLElement;
    const menu = document.querySelector('.dropdown-menu');
    const userIcon = document.querySelector('.user');

    if (!menu?.contains(target) && !userIcon?.contains(target)) {
      this.isMenuOpen = false;
    }
  }
  
  cerrarSesion(){
    localStorage.removeItem('token_taskhub');
    localStorage.removeItem('user_taskhub');
    this.router.navigate(['/login']);
  }

}
