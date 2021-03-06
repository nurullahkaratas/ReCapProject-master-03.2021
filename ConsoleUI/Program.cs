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
            //CarDetailsDtoMethod();
            // CarManagerMethod();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental { CarId = 1,CustomerId=2, RentDate = DateTime.Now, ReturnDate = DateTime.Today };
            rentalManager.Add(rental1);
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.RentDate);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void CarManagerMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            Car newCar1 = new Car { BrandId = 2, ColorId = 2,CarName="Toyotaa" ,DailyPrice = 205000, ModelYear = 2021, Descriptions = "Otomatik " };
            carManager.Add(newCar1);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "---" + car.Descriptions);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDetailsDtoMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "-" + car.ColorName +"-"+car.BrandName+"-"+car.DailyPrice);

            }
        }

        
    }
}
