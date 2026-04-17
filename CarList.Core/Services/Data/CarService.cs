using CarApiClean.DTOs.Responses;
using CarList.Core.Interfaces.Repositories;
using CarList.Core.Interfaces.Services.Data;
using CarList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Core.Services.Data
{
    public class CarService(ICarRepo _repository) : ICarService
    {
        public async Task Delete(Car? existingCar)
        {
            await _repository.Delete(existingCar);
        }

        public async Task<IEnumerable<Car>> Getall()
        {
            return await _repository.GetAll();
        }

        public async Task<Car?> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task PacthAsync(Car? existingCar)
        {
            await _repository.PatchAsync(existingCar);
        }

        public async Task<Car?> Post(CarAddResponseDTO carDTO)
        {
            var NewCar = new Car
            {
                Id = Guid.NewGuid(),
                Tire = carDTO.Tire,
                Models = carDTO.Models,
                HorsePower = carDTO.HorsePower,
                PersonneId = carDTO.PersonneId,
            };
            await _repository.Post(NewCar);

            return NewCar;
        }

        public async Task Put(Car car, Guid id)
        {
            await _repository.Put(car, id);
        }
    }
}
