﻿
using Modelo;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Modelo.ViewModels;
namespace Persistencia.DAL
{
    public class ConsultaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Consulta> ObterConsultasClassificadasPorData()
        {
            return context.Consultas.Include(c => c.Pet).Include(f => f.Veterinario).
            OrderBy(n => n.data_hora);
        }
        public Consulta ConsultaOriginal(ConsultaViewModel consultaViewModel)
        {
            return context.Consultas.Find(consultaViewModel.Id);
        }
        public Consulta ObterConsultaPorId(long id)
        {
            return context.Consultas.Where(p => p.Id == id).Include(c => c.Exames).First();
        }
        public ICollection<ExameVinculado> PopularExames()
        {
            var exames = context.Exames;
            var examesvinculados = new List<ExameVinculado>();

            foreach (var item in exames)
            {
                examesvinculados.Add(new ExameVinculado
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Vinculado = false
                });
            }

            return examesvinculados;
        }


        public void AddOrUpdateExames(Consulta consulta, IEnumerable<ExameVinculado> examesvinculados)
        {
            if (examesvinculados == null) return;

            if (consulta.Id != 0)
            {
                // consulta existente - apaga exames existentes e adiciona novos (se tiver)
                foreach (var exame in consulta.Exames.ToList())
                {
                    consulta.Exames.Remove(exame);
                }

                foreach (var exame in examesvinculados.Where(c => c.Vinculado))
                {
                    consulta.Exames.Add(context.Exames.Find(exame.Id));
                }
            }
            else
            {
                // Nova Consulta
                foreach (var exameVinculado in examesvinculados.Where(c => c.Vinculado))
                {
                    var exame = new Exame { Id = exameVinculado.Id };
                    context.Exames.Attach(exame);
                    consulta.Exames.Add(exame);
                }
            }
        }
        public void GravarConsulta(Consulta consulta)
        {
            if (consulta.Id == 0)
            {
                context.Consultas.Add(consulta);
            }
            else
            {
                context.Entry(consulta).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

    }
}