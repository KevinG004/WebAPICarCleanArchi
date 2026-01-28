using CarList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Core.Interfaces.Repositories
{
    public interface ICarRepo
    {
        public Task<IEnumerable<Car>> GetAll();

        public Task<Car?> GetById(Guid Id);

        public Task Post(Car? car);

        public Task Delete(Car existingCar);
        Task Put(Car car, Guid id);
        Task PatchAsync(Car? existingCar);
    }
}
