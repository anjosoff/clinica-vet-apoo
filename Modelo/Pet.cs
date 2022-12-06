using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pet
    {
        public long PetId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public TipoSexo Sexo { get; set; }
        public enum TipoSexo
        {
            [Display(Name = "Feminino")]
            FEM,
            [Display(Name = "Feminino")]
            MASC
        }
    }
}