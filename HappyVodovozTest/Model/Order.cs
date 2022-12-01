using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public int PersonId { get; set; }
        public List<Person>? Persons { get; set; }
    }
}
