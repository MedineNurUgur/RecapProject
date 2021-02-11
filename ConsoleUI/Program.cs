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
            //GetCarTest();
            GetCarDetailTest();

            AddCarTest();

            //AddBrandTest();
            //AddColorTest();

        }

        private static void AddCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.AddCar(new Car { CarName = "Civic", BrandId = 1002, ColorId = 1002, DailyPrice = 12.0, Descriptions = "lsdjdhf" });
        }

        private static void AddColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.AddColor(new Color { ColorName = "Füme" });
        }

        private static void AddBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.AddBrand(new Brand { BrandName = "Honda" });
        }

        private static void GetCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var i in carManager.GetAll().Data)
            {
                Console.WriteLine(i.Descriptions);
            }
        }
        private static void GetCarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " / " + car.ColorName + " / " + car.BrandName + " / " + car.DailyPrice);
            }
        }
    }
}
