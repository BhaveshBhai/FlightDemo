import { HttpHeaders } from '@angular/common/http';

export class Configuration {
  static httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  //Web api path
  static apiUrl = 'http://localhost:52952/api/';
}
