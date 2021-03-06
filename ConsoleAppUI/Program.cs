﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Repository;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleAppUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //  UserTest();
            // CustomerTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rent = new Rental
            {
                RentalCarId = 1,
                RentDate = DateTime.Now,
                RentalCustomerId = 1,
            };
            var result = rentalManager.Add(rent);
            Console.WriteLine(result.Message);
            rent.ReturnDate = DateTime.Now;
            rent.RentalId = 3;
            var resultUpdate = rentalManager.Update(rent);
            Console.WriteLine(resultUpdate.Message);
            /* ColorManager.Add(new Color { ColorName = "White" });
             ColorManager.Add(new Color { ColorName = "Red" });
             ColorManager.Add(new Color { ColorName = "Green" });
             ColorManager.Add(new Color { ColorName = "Yellow" });
             ColorManager.Add(new Color { ColorName = "Gray" });
             ColorManager.Add(new Color { ColorName = "Black" });
             ColorManager.Add(new Color { ColorName = "Blue" });


             brandManager.Add(new Brand { BrandName = "Tofaş" });
             brandManager.Add(new Brand { BrandName = "Ford" });
             brandManager.Add(new Brand { BrandName = "Volkwagen" });
             brandManager.Add(new Brand { BrandName = "Volvo" });
             brandManager.Add(new Brand { BrandName = "Renault" });
             brandManager.Add(new Brand { BrandName = "Opel" });

             carManager.Add(new Car { ColorId = 1, BrandId = 1, ModelYear = 1992, DailyPrice = 50, CarDescription = "Şahin Modeifiyeli" });
             carManager.Add(new Car { ColorId = 2, BrandId = 2, ModelYear = 2016, DailyPrice = 90, CarDescription = "Ford Courier otomatik vites" });
             carManager.Add(new Car { ColorId = 4, BrandId = 3, ModelYear = 2018, DailyPrice = 180, CarDescription = "Volkswagen Jetta Full" });

             carManager.Add(new Car { ColorId = 4, BrandId = 3, ModelYear = 2018, DailyPrice = 0, CarDescription = "Volkswagen Jetta Full" });
             carManager.Add(new Car { ColorId = 4, BrandId = 3, ModelYear = 2018, DailyPrice = 100, CarDescription = "l" });*/
            Console.WriteLine("\n\n");
            Console.WriteLine("--------------------Color Id : 1 Item list--------------------");
            var resultColor = colorManager.GetById(1).Data;
            Console.WriteLine("ColorId \t ColorName ");
            Console.WriteLine("{0} \t\t {1}", resultColor.ColorId, resultColor.ColorName);

            Console.WriteLine("--------------------Brand Id : 2 Item list--------------------");
            var resultBrand = brandManager.GetById(2).Data;
            Console.WriteLine("BrandId \t BrandName ");
            Console.WriteLine("{0} \t\t {1}", resultBrand.BrandId, resultBrand.BrandName);
            Console.WriteLine("\n\n");

            GetList(carManager.GetAll().Data);
            GetItem(carManager.GetCarDetailByCarId(1).Data);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer()
            {
                UserId = 1,
                CompanyName = "Ozonlu"
            });
        }

        private static void UserTest()
        {
            var userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                UserFirstName = "Mehmet",
                UserLastName = "Ozonlu",
                UserPassword = "123",
                UserEmail = "mehmetozonlu@gmail.com"
            });
        }

        static void GetList(List<CarDetailDto> cars)
        {
            Console.WriteLine("\n************************************LIST************************************\n");
            Console.WriteLine("CarId \t Color Name \t Brand Name \t DailyPrice \t Model Year \t Description");
            foreach (var car in cars)
            {
                if (car.BrandName.Length > 6)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3} \t\t {4} \t\t {5}", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.ModelYear, car.CarDescription);
                }
                else
                {
                    Console.WriteLine("{0} \t {1} \t\t {2} \t\t {3} \t\t {4} \t\t {5}", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.ModelYear, car.CarDescription);
                }

            }
        }
        static void GetItem(CarDetailDto car)
        {
            Console.WriteLine("\n*****************************************************************\n");
            Console.WriteLine("CarId \t Color Name \t Brand Name \t DailyPrice \t Model Year \t Description");
            if (car.BrandName.Length > 6)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t\t {4} \t\t {5}", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.ModelYear, car.CarDescription);
            }
            else
            {
                Console.WriteLine("{0} \t {1} \t\t {2} \t\t {3} \t\t {4} \t\t {5}", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.ModelYear, car.CarDescription);
            }

        }
    }
}
