using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() { 
            new Car() { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 170 ,Description="Dacia Duster 1.5 dCI 2020"}, 
            new Car() { Id = 2, BrandId = 2, ColorId = 3, ModelYear = 2021, DailyPrice = 200 ,Description="Volkswagen Polo 1.5 TSI 2021"},
            new Car() { Id = 3, BrandId = 3, ColorId = 2, ModelYear = 2019, DailyPrice = 300 },
            new Car() { Id = 4, BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 150 },
            new Car() { Id = 5, BrandId = 2, ColorId = 4, ModelYear = 2020, DailyPrice = 185 }};
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car DeleteToCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(DeleteToCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Car car)
        {
            return _cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public List<Car> GetCarDetails(int carID)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car UpdateToCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            UpdateToCar.BrandId = car.BrandId;
            UpdateToCar.ColorId = car.ColorId;
            UpdateToCar.ModelYear = car.ModelYear;
            UpdateToCar.DailyPrice = car.DailyPrice;
            UpdateToCar.Description = car.Description;
        }

        List<CarDetailDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
