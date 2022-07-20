using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class ArtisanManager:IArtisanService
    {
        IArtisanDal _artisanDal;
        public ArtisanManager(IArtisanDal artisanDal)
        {
            _artisanDal = artisanDal;
        }

        public IResult Add(EsnafDto esnafDto)
        {
            
            //_artisanDal.Add(esnafDto);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(Artisan artisan)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Artisan>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Artisan> GetById(int artisanId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Artisan artisan)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<esnafOrdersDto>> GetOrdersById(int artisanId)
        {
            return new SuccessDataResult<List<esnafOrdersDto>>(_artisanDal.GetOrdersById(x => x.EsnafId == artisanId));
        }
        public IDataResult<List<esnafAnswerDto>> GetQuastionsById(int artisanId)
        {
            return new SuccessDataResult<List<esnafAnswerDto>>(_artisanDal.GetQuastionsById(x => x.sellerId == artisanId));
        }

        public IDataResult<List<esnafOrdersDto>> GetOrdersDtoForAdmin()
        {
            return new SuccessDataResult<List<esnafOrdersDto>>(_artisanDal.GetOrdersById());
        }
    }
}
