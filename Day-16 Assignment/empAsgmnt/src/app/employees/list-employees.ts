import { Component } from '@angular/core';
import { Employee } from '../../models/employee';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-list-employees',
  imports: [DatePipe],
  templateUrl: './list-employees.html',
  styleUrl: './list-employees.css',
})
export class ListEmployees {
  employees: Employee[] = [
    {
      id: 1,
      name: 'Mark',
      gender: 'Male',
      contactPreference: 'Email',
      email: 'mark@gmail.com',
      dateOfBirth: new Date('10/25/1990'),
      department: 'IT',
      isActive: true,
      photoPath: 'emp1.webp'
    },
    {
      id: 2,
      name: 'Mary',
      gender: 'Female',
      contactPreference: 'Phone',
      phoneNumber: 9876543210,
      dateOfBirth: new Date('08/15/1992'),
      department: 'HR',
      isActive: true,
      photoPath: 'emp2.png'
    },
    {
      id: 3,
      name: 'John',
      gender: 'Male',
      contactPreference: 'Phone',
      phoneNumber: 9123456780,
      dateOfBirth: new Date('06/12/1988'),
      department: 'Finance',
      isActive: false,
      photoPath: 'emp3.webp'
    }
  ];

}
