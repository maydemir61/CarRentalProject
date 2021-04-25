using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll(int carid);
        IDataResult<CarImage> GetByImageId(int imageid);
        IResult Add(CarImage carImage,IFormFile file);
        IResult Update(CarImage carImage,IFormFile file);
        IResult Delete(CarImage carImage);
    }
}
