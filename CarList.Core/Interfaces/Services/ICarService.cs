using CarApiClean.DTOs.Responses;
using CarList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Core.Interfaces.Services
{
    public interface ICarService
    {
        public Task<Car?> Post(CarAddResponseDTO car);

        public Task<IEnumerable<Car>> Getall();
        public Task Put(Car car, Guid id);
        Task<Car?> GetById(Guid id);
        Task Delete(Car? existingCar);
        Task PacthAsync(Car? existingCar);
    }
}
