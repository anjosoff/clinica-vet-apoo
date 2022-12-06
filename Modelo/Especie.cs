using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Especie
    {
        public long EspecieId { get; set; }
        public string Nome { get; set; }
        public IList<Pet> Pets { get; set; }
    }
}