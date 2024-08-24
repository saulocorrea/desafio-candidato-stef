import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  private apiUrl = 'http://localhost:5258/pedido';

  constructor(private http: HttpClient) { }

  obterTodos(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  obterPorId(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  adicionar(pedido: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, pedido);
  }

  alterar(id: number, pedido: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, pedido);
  }

  deletar(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}
