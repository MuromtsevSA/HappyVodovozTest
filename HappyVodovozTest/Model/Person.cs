using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patromynic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public List<Order>? Orders { get; set; } 
    }

    public enum Gender
    {
        Male,
        Female
    }

}
