using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinica_vet.Servico
{
    class ExameServico
    {
        private ExameDAL exameDAL = new ExameDAL();
        public IQueryable<Exame> ObterExamesClassificadosPorDesc()
        {
            return exameDAL.ObterExamesClassificadosPorDesc();
        }
        public Exame ObterExamePorId(long id)
        {
            return exameDAL.ObterExamePorId(id);
        }
        public void GravarExame(Exame exame)
        {
            exameDAL.GravarExame(exame);
        }
        public Exame EliminarExamePorId(long id)
        {
            Exame exame = exameDAL.ObterExamePorId(id);
            exameDAL.EliminarExamePorId(id);
            return exame;
        }
    }
}