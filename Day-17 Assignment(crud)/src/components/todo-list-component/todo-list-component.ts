import { ChangeDetectorRef, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TodoService } from '../../services/todo-service';

@Component({
  selector: 'app-todo-list-component',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-list-component.html',
  styleUrl: './todo-list-component.css',
})
export class TodoListComponent {

  constructor(private todoService: TodoService,private cdr:ChangeDetectorRef) {}

  todos: any[] = [];
  newTodo: string = '';
  editTodo: any = null;

  ngOnInit() {
    this.loadTodos();
  }

  // Initial Load
  loadTodos() {
    this.todoService.getTodos().subscribe(data => {
      this.todos = data;
      this.cdr.detectChanges()
    });
  }

  // CREATE
  addTodo() {
    if (!this.newTodo.trim()) return;

    const todo = { title: this.newTodo, completed: false };

    this.todoService.addTodo(todo).subscribe(createdTodo => {
      this.todos.push(createdTodo);   // ✅ Instant UI update
      this.newTodo = '';
      this.cdr.detectChanges()
    });
  }

  // Enable Edit Mode
  startEdit(todo: any) {
    this.editTodo = { ...todo };
  }

  // UPDATE
  updateTodo() {
    this.todoService.updateTodo(this.editTodo).subscribe(updatedTodo => {
      const index = this.todos.findIndex(t => t.id === updatedTodo.id);
      this.todos[index] = updatedTodo;   // ✅ Instant UI update
      this.editTodo = null;
      this.cdr.detectChanges()
    });
  }

  // DELETE
  deleteTodo(id: number) {
    this.todoService.deleteTodo(id).subscribe(() => {
      this.todos = this.todos.filter(todo => todo.id !== id);
      this.cdr.detectChanges() // ✅ Instant UI update
    });
  }
}
