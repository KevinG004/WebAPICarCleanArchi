using CarList.Core.Interfaces.Repositories;
using CarList.Domain.Entities;
using CarList.Infrastucture.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Infrastucture.Repositories
{
    public class CarRepo(DataContext _context) : ICarRepo
    {
        protected DbSet<Car> _cars = _context.Set<Car>();
        public async Task Delete(Car existingCar)
        {
            _context.Remove(existingCar);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }

        public async  Task<Car?> GetById(Guid Id)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task PatchAsync(Car? existingCar)
        {
            _context.Cars.Update(existingCar);
            await _context.SaveChangesAsync();
        }

        public async Task Post(Car? car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task Put(Car car, Guid id)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }
    }
}
