using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal :ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2012,Description="Toyota",DailyPrice=150},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2013,Description="Toyota",DailyPrice=130},
                new Car{Id=3,BrandId=2,ColorId=3,ModelYear=2009,Description="Mercedes",DailyPrice=140},
                new Car{Id=4,BrandId=3,ColorId=4,ModelYear=2015,Description="Audi",DailyPrice=190},
                new Car{Id=5,BrandId=4,ColorId=5,ModelYear=2010,Description="Kia",DailyPrice=120},

            };

            _brands = new List<Brand>()
            {
                new Brand{Id=1,BrandName="Toyota"},
                new Brand{Id=2,BrandName="Mercedes"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Car added.");
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete=_cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("Car deleted.");
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            car.BrandId = carToUpdate.BrandId;
            car.ColorId = carToUpdate.ColorId;
            car.DailyPrice = carToUpdate.DailyPrice;
            car.Description = carToUpdate.Description;
            car.ModelYear = carToUpdate.ModelYear;
        }
        public void Test()
        {
            var result = from c in _cars
                         where c.Description.Contains("i")
                         select c;
            foreach (var item in result)
            {
                Console.WriteLine(item.Description);
            }
            
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> carDetails()
        {
            throw new NotImplementedException();
        }
    }
}
