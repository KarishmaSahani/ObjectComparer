using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] Marks { get; set; }

        public List<string> Courses { get; set; } = new List<string>();
    }
}
