using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWPFapp.Models
{
    internal class Departaments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Workers> Workers { get; set; } = new List<Workers>();

    }
}
