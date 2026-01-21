import { Component } from '@angular/core';
import { User } from '../../interface/user';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-usercomp',
  imports: [FormsModule],
  templateUrl: './usercomp.html',
  styleUrl: './usercomp.css',
})
export class Usercomp {
  // Array of users
  users: User[] = [];

  // Single user object
  user: User = {
    id: 0,
    name: '',
    email: ''
  };

  // Edit mode flag
  isEditMode = false;

  // CREATE & UPDATE
  saveUser() {
    if (this.isEditMode) {
      const index = this.users.findIndex(u => u.id === this.user.id);
      this.users[index] = { ...this.user };
      this.isEditMode = false;
    } else {
      this.user.id = Date.now();
      this.users.push({ ...this.user });
    }
    this.resetForm();
  }

  // READ (Edit)
  editUser(selectedUser: User) {
    this.user = { ...selectedUser };
    this.isEditMode = true;
  }

  // DELETE
  deleteUser(id: number) {
    this.users = this.users.filter(u => u.id !== id);
  }

  // Reset form
  resetForm() {
    this.user = { id: 0, name: '', email: '' };
  }


}
