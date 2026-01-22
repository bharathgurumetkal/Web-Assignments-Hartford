import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TodoService {

  private apiUrl = 'http://localhost:3000/todos';

  constructor(private http: HttpClient) {}

  getTodos() {
    return this.http.get<any[]>(this.apiUrl);
  }

  addTodo(todo: any) {
    return this.http.post<any>(this.apiUrl, todo);
  }

  updateTodo(todo: any) {
    return this.http.put<any>(`${this.apiUrl}/${todo.id}`, todo);
  }

  deleteTodo(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
