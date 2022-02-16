using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using csharp_gregslist.Models;
using Dapper;

namespace csharp_gregslist.Repositories
{
    public class CarsRepository
    {
        private readonly IDbConnection _db;
        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Car> Get()
        {
            string sql = "SELECT* FROM cars;";
            List<Car> cars = _db.Query<Car>(sql).ToList();
            return cars;
        }

        internal Car Get(int carId)
        {
            string sql = "SELECT* FROM cars WHERE id = @carId";
            Car foundCar = _db.QueryFirstOrDefault<Car>(sql, new { carId });
            return foundCar;
        }

        internal Car Create(Car newCar)
        {
            string sql = @"
            INSERT INTO cars
            (year, make, model, price, description, imgUrl)
            VALUES
            (@Year, @Make, @Model, @Price, @Description, @ImgUrl);
            SELECT LAST_INSERT_ID();
           ";
            int id = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = id;
            return newCar;
        }

        internal void Edit(Car original)
        {
            string sql = @"
            UPDATE cars
            SET
            year = @Year,
            make = @Make, 
            model = @Model, 
            price = @Price, 
            description = @Description, 
            imgUrl = @ImgUrl
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int carId)
        {
            string sql = "DELETE FROM cars WHERE id = @carId LIMIT 1";
            int deleted = _db.Execute(sql, new { carId });
            if (deleted == 0)
            {
                throw new System.Exception("Unable to delete");
            }
        }
    }
}