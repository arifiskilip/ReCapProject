using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();

            //Test2();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.CarId = 1;
            rental.CustomerId = 1;
            rental.RentDate = new DateTime(2021, 10, 17);
            rental.ReturnDate = new DateTime(2021, 10, 18);

            var result =rentalManager.Add(rental);
            Console.WriteLine(result.Message);

        }

      
        private static void Test1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = 4, BrandId = 1, ColorId = 2, DailyPrice = 0, ModelYear = 2001, Description = "Toyota" });
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(" Marka : {0}     Model : {1}     Fiyat : {2}TL", item.Description, item.ModelYear, item.DailyPrice);
            }
        }
    }
}
