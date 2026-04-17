using CarList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Core.Interfaces.Repositories
{
    public interface IPersonneRepo
    {
        public Task<IEnumerable<Personne>> GetAll();

        public Task<Personne?> GetById(Guid Id);

        public Task Post(Personne personne);

        public Task Delete(Personne existingPersonne);
        Task Put(Personne personne, Guid id);
        Task PatchAsync(Personne? existingPersonne);
    }
}
