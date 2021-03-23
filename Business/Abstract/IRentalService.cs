using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult AddRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<Rental>> GetByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
