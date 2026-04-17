using CarApiClean.DTOs.Responses;
using CarList.Core.DTOs.Responses;
using CarList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Core.Interfaces.Services.Data
{
    public interface IPersonneService
    {
        public Task<Personne> Post(PersonneAddResponseDTO personne);

        public Task<IEnumerable<PersonneAddResponseDTO>> Getall();

        public Task Put(Personne personne, Guid id);

        Task<PersonneAddResponseDTO?> GetById(Guid id);

        Task Delete(Guid id);

        Task PatchAsync(Guid id, string email);
    }
}
