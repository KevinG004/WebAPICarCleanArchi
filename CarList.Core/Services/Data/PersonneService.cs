using CarApiClean.DTOs.Responses;
using CarList.Core.DTOs.Responses;
using CarList.Core.Interfaces.Repositories;
using CarList.Core.Interfaces.Services.Data;
using CarList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Core.Services.Data
{
    public class PersonneService(
        IPersonneRepo _personne,
        IHashPassword _password
        ) : IPersonneService
    {
        public async Task Delete(Guid id)
        {
            var personne = await _personne.GetById(id);
            if (personne != null)
            {
                await _personne.Delete(personne);
            }
        }

        public async Task<IEnumerable<PersonneAddResponseDTO>> Getall()
        {
            var personnes = await _personne.GetAll();

            return personnes.Select(p => new PersonneAddResponseDTO
            {
                Email = p.Email,
                FirstName = p.FirstName,
                Password = p.Password,
                LastName = p.LastName,
                Cars = p.Cars?.Select(c => new CarAddResponseDTO
                {
                    Models = c.Models,
                    Tire = c.Tire,
                    HorsePower = c.HorsePower,
                    PersonneId = c.PersonneId
                })
            });
        }

        public async Task<PersonneAddResponseDTO?> GetById(Guid id)
        {
            var personne = await _personne.GetById(id);

            if (personne == null) return null;

            return new PersonneAddResponseDTO
            {
                Email = personne.Email,
                FirstName = personne.FirstName,
                Password = personne.Password,
                LastName = personne.LastName,
                Cars = personne.Cars?.Select(c => new CarAddResponseDTO
                {
                    Models = c.Models,
                    Tire = c.Tire,
                    HorsePower = c.HorsePower,
                    PersonneId = c.PersonneId
                })
            };
        }

        public async Task PatchAsync(Guid id, string email)
        {
            var personne = await _personne.GetById(id);
            if (personne != null)
            {
                personne.Email = email;
                await _personne.PatchAsync(personne);
            }
        }

        public async Task<Personne> Post(PersonneAddResponseDTO personne)
        {
            var hashedPassword = _password.HashPassword1(personne.Password);

            var NewPersonne = new Personne
            {
                Id = Guid.NewGuid(),
                Email = personne.Email,
                Password = hashedPassword,
                FirstName = personne.FirstName,
                LastName = personne.LastName,
            };
            await _personne.Post(NewPersonne);

            return NewPersonne;
        }

        public async Task Put(Personne personne, Guid id)
        {
            await _personne.Put(personne, id);
        }
    }
}
