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
    public class PetDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Pet> ObterPetsClassificadosPorNome()
        {
            return context.Pets.OrderBy(d => d.Nome);
        }

        public Pet ObterPetPorId(long id)
        {
            return context.Pets.Where(e => e.PetId == id).First();
        }

        public void GravarPet(Pet pet)
        {
            if (pet.PetId == null)
            {
                context.Pets.Add(pet);
            }
            else
            {
                context.Entry(pet).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Pet EliminarPetPorId(long id)
        {
            Pet pet = ObterPetPorId(id);
            context.Pets.Remove(pet);
            context.SaveChanges();
            return pet;
        }
    }
}