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
            // UserAddTest();
            // RentalControllerTest();
            // CustomerAddTest();
            // UserDeleteTest();

            
        }

        private static void UserAddTest()
        {
            User user1 = new User() { FirstName = "Bilal Can", LastName = "Altındağ", Email = "bilalcanaltindag@hotmail.com", Password = "141516" };
            User user2 = new User() { FirstName = "Efe", LastName = "Altındağ", Email = "efealtindag@outlook.com", Password = "12345" };
            User user3 = new User() { FirstName = "Tamer", LastName = "Çetin", Email = "tmrctn15@hotmail.com", Password = "416141" };
            User user4 = new User() { FirstName = "Osman", LastName = "Bilgintürk", Email = "osmanbilgin@hotmail.com", Password = "414141" };

            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(user4);

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.UserId + " - " + user.FirstName + " " + user.LastName);
            }
        }

        private static void UserDeleteTest()
        {
            User user5 = new User();
            user5.UserId = 4;
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Delete(user5);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.UserId + " - " + user.FirstName + " " + user.LastName);
            }
        }

        private static void CustomerAddTest()
        {
                CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
                customerManager.Add(new Customer { UserId = 2, CompanyName = "Altındağ" });

        }

        private static void RentalControllerTest()
        {
                RentalManager rentalManager = new RentalManager(new EfRentalDal());
                rentalManager.Add(new Rental { CarId = 5, CustomerId = 1, RentDate = new DateTime(2022, 03, 18, 09, 00, 00), ReturnDate = new DateTime(2022, 05, 18, 09, 00, 00) });
                foreach (var rent in rentalManager.GetAll().Data)
                {
                    Console.WriteLine(rent.CustomerId);
                }
            
        }

        private static void BrandTest(BrandManager brandManager)
        {
            Console.WriteLine(brandManager.GetById(2));

            Brand brand1 = new Brand() { BrandName = "BMW" };
            brandManager.Add(brand1);

            brandManager.Add(brand1);
            brandManager.Delete(brand1);
            brandManager.Update(brand1);

            Console.WriteLine(brandManager.GetById(8));

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Color color1 = new Color() { ColorName = "Beyaz" };
            Color color2 = new Color() { ColorId = 3, ColorName = "Füme" };


            colorManager.Update(color2);

            Console.WriteLine(colorManager.GetById(3));

            foreach (var color in colorManager.GetAll().Data)
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
