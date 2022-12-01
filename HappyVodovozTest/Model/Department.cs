using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person? person { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
