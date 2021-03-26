using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public CarDetailDto GetCarByCarIdWithDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {

                var result = from c in  context.Cars.Where(filter) 
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId 
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = (float)c.DailyPrice,
                                 ModelYear = c.ModelYear
                             };
                return result.FirstOrDefault();

            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {

                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = (float)c.DailyPrice,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();

            }
        }
    }
}
