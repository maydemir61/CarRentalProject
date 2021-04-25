using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helper;
using Core.Utilities.Business;
using Business.BusinessAspect.Autofac;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [SecuredOperation("product.add")]
        public IResult Add(CarImage carImage, IFormFile file)
        {

            IResult result = BusinessRules.Run(CheckImageQuantity(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Create(file);
            carImage.Date = DateTime.Now.ToString();
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = new SuccessResult();
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            FileHelper.Delete(carImage.ImagePath);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll(int carid)
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carid));
        }

        public IDataResult<CarImage> GetByImageId(int imageid)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageid));
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            FileHelper.Update(carImage.ImagePath, file);
            _carImageDal.Update(carImage);

            return new SuccessResult();
        }

        private IResult CheckImageQuantity(int carid)
        {
            var result = GetAll(carid);
            if (result.Data.Count > 5)
            {
                return new ErrorResult("Araç fotoğraf sayısı 5'ten büyük olamaz.");
            }

            return new SuccessResult();
        }
    }
}
