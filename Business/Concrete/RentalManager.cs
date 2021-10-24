using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(c => c.CarId == rental.CarId);
            if (result == null && result.RentDate<=result.ReturnDate)
            {
                _rentalDal.Add(rental);
                return new SuccesResult(Messages.RentalAdded);
            }
                return new ErrorResult(Messages.RentalInvalid);
        }
    }
}
