export class MenuModel {
  constructor(){
    this.url = '';
    this.icon = '';
    this.name = '';
    this.children = [];
  }
  url: string;
  icon: string;
  name: string;
  children?: MenuModel[];
}
