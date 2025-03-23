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
        return this.http.post<ResponseApi>(`${this.urlApi}Guardar`,request)
    }
    editar(request:Producto):Observable<ResponseApi>{
        return this.http.put<ResponseApi>(`${this.urlApi}Editar`,request)
    }
    eliminar(id:number):Observable<ResponseApi>{
        return this.http.delete<ResponseApi>(`${this.urlApi}Eliminar/${id}`)
    }
}
