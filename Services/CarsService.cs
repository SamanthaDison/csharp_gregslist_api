using System;
using System.Collections.Generic;
using csharp_gregslist.Models;
using csharp_gregslist.Repositories;

namespace csharp_gregslist.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;
        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }

        internal List<Car> Get()
        {
            List<Car> cars = _repo.Get();
            return cars;
        }

        internal Car Get(int carId)
        {
            Car foundCar = _repo.Get(carId);
            if (foundCar == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundCar;
        }

        internal Car Create(Car newCar)
        {
            Car car = _repo.Create(newCar);
            return car;
        }

        internal Car Edit(Car updates)
        {
            Car original = Get(updates.Id);
            original.Year = updates.Year > 0 ? updates.Year : original.Year;
            original.Make = updates.Make != null ? updates.Make : original.Make;
            original.Model = updates.Model != null ? updates.Model : original.Model;
            original.Price = updates.Price != 0 ? updates.Price : original.Price;
            original.Description = updates.Description != null ? updates.Description : original.Description;
            original.ImgUrl = updates.ImgUrl != null ? updates.ImgUrl : original.ImgUrl;
            _repo.Edit(original);
            return original;
        }

        internal void Delete(int carId)
        {
            Get(carId);
            _repo.Delete(carId);
        }
    }

}