import { Component, OnInit } from '@angular/core';
import { ActivationEnd, Router } from '@angular/router';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  titulo: string;
  constructor(private router: Router) {
    this.titulo = '';
    this.router.events.pipe(
      filter((resp: any) => resp instanceof ActivationEnd),
      filter((resp: ActivationEnd) => resp.snapshot.firstChild == null),
      map((event: ActivationEnd) => event.snapshot.data)
    ).subscribe(({titulo}) => {
      this.titulo = titulo;
      document.title = `Test Pixel - ${titulo}`;
    })
  }

  ngOnInit(): void {
  }

}
