
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddCarImage(CarImage carImage, IFormFile file);
        IResult DeleteCarImage(CarImage carImage, IFormFile file);
        IResult UpdateCarImage(CarImage carImage, IFormFile file);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<CarImage> GetById(int imageId);
    }
}

