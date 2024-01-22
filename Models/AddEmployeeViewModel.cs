﻿
using Microsoft.Build.Framework;

namespace WebApplication2.Models
{
    public class AddEmployeeViewModel
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Department { get; set; }
    }
}