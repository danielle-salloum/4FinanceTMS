﻿using Microsoft.AspNetCore.Http;

namespace _4FinanceTMS.Models
{
    public class Course 
    {
        public Guid Id { get; set; }
        public int CreditNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
