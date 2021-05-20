import { Component, OnInit } from '@angular/core';
import { MenuModel } from '../../models/menu';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  ver = true;
  menu: MenuModel[];
  constructor() {
    this.menu = [];
  }

  ngOnInit(): void {
    let boton = document.getElementById('btnCollapseMenu');
    console.log(boton);
    boton?.click();

    this.menu = [
      {
        url: '',
        icon: 'lni lni-home',
        name: 'Dashboard',
      },
      {
        url: '',
        icon: 'lni lni-user',
        name: 'Clientes',
      },
      {
        url: '',
        icon: 'lni lni-consulting',
        name: 'Préstamos',
      },
      {
        url: '',
        icon: 'lni lni-invest-monitor',
        name: 'Estado de Cuenta'
      },
      // Para los casos que tenga submenu
      // {
      //   url: 'javascript:void(0)',
      //   icon: 'ion-monitor',
      //   name: 'Ui elements',
      //   children: [
      //     {
      //       url: '',
      //       icon: 'ion-monitor',
      //       name: 'Buttons',
      //     }
      //   ],
      // }
    ]
  }

}
