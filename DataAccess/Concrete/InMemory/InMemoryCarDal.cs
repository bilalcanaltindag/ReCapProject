using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ModelYear=2006, DailyPrice=100000, Description="2006 Model Citroen C5"},
                new Car{CarId=2, BrandId=2, ModelYear=2013, DailyPrice=200000, Description="2013 Model Opel Astra"},
                new Car{CarId=3, BrandId=3, ModelYear=2022, DailyPrice=450000, Description="2022 Model Fiat Egea"},
                new Car{CarId=4, BrandId=4, ModelYear=2016, DailyPrice=380000, Description="2016 Model Volkswagen Jetta"},
                new Car{CarId=5, BrandId=2, ModelYear=2021, DailyPrice=600000, Description="2021 Model Opel Insignia"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.CarId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
