import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  ver = true;
  constructor() { }

  ngOnInit(): void {
    let boton = document.getElementById('btnCollapseMenu');
    console.log(boton);
    boton?.click();
  }

}
