import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  fechaActual: string;
  constructor() {
    let fecha = new Date();
    this.fechaActual = fecha.getFullYear().toString();
  }

  ngOnInit(): void {

  }

}
