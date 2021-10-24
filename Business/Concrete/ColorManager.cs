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
    public class ColorManager : IColorService
    {
        IColorDal _ıcolorDal;
        public ColorManager(IColorDal colorDal)
        {
            _ıcolorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            _ıcolorDal.Add(color);
            return new SuccesResult();
        }

        public IResult Delete(Color color)
        {
            _ıcolorDal.Delete(color);
            return new SuccesResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Color> GetByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            _ıcolorDal.Update(color);
            return new SuccesResult();
        }
    }
}
