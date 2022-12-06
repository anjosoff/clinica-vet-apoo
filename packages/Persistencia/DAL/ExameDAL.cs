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
    public class ExameDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Exame> ObterExamesClassificadosPorNome()
        {
            return context.Exames.OrderBy(d => d.Descricao);
        }

        public Exame ObterExamePorId(long id)
        {
            return context.Exames.Where(e => e.ExameId == id).First();
        }

        public void GravarExame(Exame exame)
        {
            if (exame.ExameId == null)
            {
                context.Exames.Add(exame);
            }
            else
            {
                context.Entry(exame).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Exame EliminarExamePorId(long id)
        {
            Exame exame = ObterExamePorId(id);
            context.Exames.Remove(exame);
            context.SaveChanges();
            return exame;
        }
    }
}