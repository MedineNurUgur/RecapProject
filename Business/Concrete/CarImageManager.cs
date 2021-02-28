using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileSystems;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult AddCarImage(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCountOfCarImage(carImage.CarId));
            if (result != null) return result;

            carImage.ImagePath = new FileManagerOnDisk().Add(file, CreateNewPath(file));
            carImage.UploadDate = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult DeleteCarImage(CarImage carImage, IFormFile file)
        {
            _carImageDal.Delete(carImage);
            new FileManagerOnDisk().Delete(carImage.ImagePath);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        public IResult UpdateCarImage(CarImage carImage, IFormFile file)
        {
            var carImageToUpdate = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            carImage.CarId = carImageToUpdate.CarId;
            carImage.ImagePath = new FileManagerOnDisk().Update(carImageToUpdate.ImagePath, file, CreateNewPath(file));
            carImage.UploadDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImageOfCarExists(carId));
            if (result != null)
            {
                return IfCarImageOfCarNotExistsAddDefault(new List<CarImage>(),carId);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
                

        }

        private IResult CheckCarImageOfCarExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> IfCarImageOfCarNotExistsAddDefault(List<CarImage> result, int carId)
        {
            var defaultCarImage = new CarImage
            {
                CarId = carId,
                ImagePath =
                        $@"{Environment.CurrentDirectory}\Public\Images\CarImage\default-img.png",
                UploadDate = DateTime.Now
            };
            result.Add(defaultCarImage);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        private IResult CheckCountOfCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5) return new ErrorResult(Messages.CarImageCountOfCarError);
            return new SuccessResult();
        }

        private string CreateNewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var newPath =
                $@"{Environment.CurrentDirectory}\Public\Images\CarImage\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

            return newPath;
        }
    }
}
