using CarList.Core.Interfaces.Repositories;
using CarList.Domain.Entities;
using CarList.Infrastucture.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Infrastucture.Repositories
{
    public class PersonneRepo(DataContext _context) : IPersonneRepo
    {
        protected DbSet<Personne> _personnnes = _context.Set<Personne>();
        public async Task Delete(Personne existingPersonne)
        {
            _context.Remove(existingPersonne);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Personne>> GetAll()
        {
            return await _context.Personnes
                .Include(p => p.Cars)
                .ToListAsync();
        }

        public async Task<Personne?> GetById(Guid Id)
        {
            return await _context.Personnes
                .Include(p => p.Cars)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task PatchPersonneByEmail(Personne? personne)
        {
           _context.Personnes.Update(personne);
            await _context.SaveChangesAsync();
        }

        public async Task PatchAsync(Personne? existingPersonne)
        {
            _context.Personnes.Update(existingPersonne);
            await _context.SaveChangesAsync();
        }

        public async Task Post(Personne personne)
        {
            await _context.Personnes.AddAsync(personne);
            await _context.SaveChangesAsync();
        }

        public async Task Put(Personne personne, Guid id)
        {
            _context.Personnes.Update(personne);
            await _context.SaveChangesAsync();
        }
    }
}
