using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Consulta
    {
        public long ConsultaId { get; set; }
        public DateTime data_hora { get; set; }
        public string sintomas { get; set; }
        public long? ExameId { get; set; }
        public Exame Exame { get; set; }
    }
}