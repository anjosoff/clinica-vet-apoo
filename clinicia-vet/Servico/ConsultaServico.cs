using Modelo;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinica_vet.Servico
{
    class ConsultaServico
    {
        private ConsultaDAL consultaDAL = new ConsultaDAL();
        public IQueryable<Consulta> ObterConsultasClassificadasPorData()
        {
            return consultaDAL.ObterConsultasClassificadasPorData();
        }
        public Consulta ObterConsultaPorId(long id)
        {
            return consultaDAL.ObterConsultaPorId(id);
        }
        public void GravarProduto(Consulta consulta)
        {
            consultaDAL.GravarConsulta(consulta);
        }
        public Consulta EliminarConsultaPorId(long id)
        {
            return consultaDAL.EliminarConsultaPorId(id);
        }
    }
}