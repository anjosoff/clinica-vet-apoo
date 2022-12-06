using Modelo;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ConsultaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Consulta> ObterConsultasClassificadasPorData()
        {
            return context.Consultas.Include(e => e.Exame).OrderBy(d => d.data_hora);
        }

        public Consulta ObterConsultaPorId(long id)
        {
            return context.Consultas.Where(c => c.ConsultaId == id).Include(e => e.Exame).First();
        }

        public void GravarConsulta(Consulta consulta)
        {
            if (consulta.ConsultaId == null)
            {
                context.Consultas.Add(consulta);
            }
            else
            {
                context.Entry(consulta).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Consulta EliminarConsultaPorId(long id)
        {
            Consulta consulta = ObterConsultaPorId(id);
            context.Consultas.Remove(consulta);
            context.SaveChanges();
            return consulta;
        }
    }
}