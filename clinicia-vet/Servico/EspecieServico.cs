using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia.DAL;

namespace clinica_vet.Servico
{
    public class EspecieServico
    {
        private EspecieDAL especieDAL = new EspecieDAL();
        public IQueryable<Especie> ObterEspeciesClassificadasPorNome()
        {
            return especieDAL.ObterEspeciesClassificadasPorNome();
        }
        public Especie ObterEspeciePorId(long id)
        {
            return especieDAL.ObterEspeciePorId(id);
        }
        public void GravarEspecie(Especie especie)
        {
            especieDAL.GravarEspecie(especie);
        }
        public Especie EliminarEspeciePorId(long id)
        {
            Especie especie = especieDAL.ObterEspeciePorId(id);
            especieDAL.EliminarEspeciePorId(id);
            return especie;
        }
    }
}