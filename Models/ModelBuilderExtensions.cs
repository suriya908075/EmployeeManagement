﻿using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public static  class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "Mary",
                Department = Dept.IT,
                Email = "mary@oraniumtech.com",
                PhotoPath=""
            },
            new Employee
            {
                Id = 2,
                Name = "John",
                Department = Dept.HR,
                Email = "john@oraniumtech.com",
                PhotoPath = ""
            },
             new Employee
             {
                 Id = 3,
                 Name = "Sam",
                 Department = Dept.Testing,
                 Email = "Sam@oraniumtech.com",
                 PhotoPath = ""
             }
            );
        }
    }
}
