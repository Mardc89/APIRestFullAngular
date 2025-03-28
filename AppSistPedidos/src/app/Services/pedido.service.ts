import { Injectable } from '@angular/core';

import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ResponseApi } from '../Interfaces/response-api';
import { Pedido } from '../Interfaces/pedido';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

    private urlApi:string=environment.endpoint +"Pedido/";
   
    constructor(private http:HttpClient) { }
  
    registrar(request:Pedido):Observable<ResponseApi>{
      return this.http.post<ResponseApi>(`${this.urlApi}Registrar`,request)
    }
  
    historial(buscarPor:string,codigo:string,fechaInicio:string,fechaFin:string):Observable<ResponseApi>{
        return this.http.get<ResponseApi>(`${this.urlApi}Historial?buscarPor=${buscarPor}&codigo=${codigo}&fechaInicio=${fechaInicio}&=${fechaFin}`)
    }

    reporte(fechaInicio:string,fechaFin:string):Observable<ResponseApi>{
      return this.http.get<ResponseApi>(`${this.urlApi}Reporte?fechaInicio=${fechaInicio}&=${fechaFin}`)
  }

}
