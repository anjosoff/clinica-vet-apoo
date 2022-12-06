using Modelo;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class EspecieDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Especie> ObterEspeciesClassificadosPorNome()
        {
            return context.Especies.OrderBy(d => d.Nome);
        }

        public Especie ObterEspeciePorId(long id)
        {
            return context.Especies.Where(e => e.EspecieId == id).First();
        }

        public void GravarUsuario(Especie especie)
        {
            if (especie.EspecieId == null)
            {
                context.Especies.Add(especie);
            }
            else
            {
                context.Entry(especie).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Especie EliminarUsuarioPorId(long id)
        {
            Especie especie = ObterEspeciePorId(id);
            context.Especies.Remove(especie);
            context.SaveChanges();
            return especie;
        }
    }
}