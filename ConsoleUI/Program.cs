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
            CarManager carManager = new CarManager(new EfCarDal());
            /*ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.BrandName = "BMW";
            brandManager.AddBrand(brand);
            Color color = new Color();
            color.ColorName = "Beyaz";
            colorManager.AddColor(color);

            Car car = new Car();
            car.BrandId = 1;
            car.ColorId = 1;
            car.DailyPrice = 10.0f;
            car.ModelYear = 2010;
            car.Description = "Deneme";

            carManager.AddCar(car);*/


            foreach (var i in carManager.GetAll())
            {
                Console.WriteLine(i.Description);
            }
        }
    }
}
