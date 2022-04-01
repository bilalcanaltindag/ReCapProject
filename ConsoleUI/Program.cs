using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            // ColorTest(colorManager);
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            // BrandTest(brandManager);
            // GetCarDetails(carManager);
        }

        private static void BrandTest(BrandManager brandManager)
        {
            Console.WriteLine(brandManager.GetById(2).BrandName;

            Brand brand1 = new Brand() { BrandName = "BMW" };
            brandManager.Add(brand1);

            brandManager.Add(brand1);
            brandManager.Delete(brand1);
            brandManager.Update(brand1);

            Console.WriteLine(brandManager.GetById(8).BrandName);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Color color1 = new Color() { ColorName = "Beyaz" };
            Color color2 = new Color() { ColorId = 3, ColorName = "Füme" };


            colorManager.Update(color2);

            Console.WriteLine(colorManager.GetById(3).ColorName);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} {1} {2} {3} - {4} -- {5}", car.BrandName, car.ModelName, car.ModelYear, car.ColorName, car.DailyPrice, car.Description);
            }
        }
    }
}
