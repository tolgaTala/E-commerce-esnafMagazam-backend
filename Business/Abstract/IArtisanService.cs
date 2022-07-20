using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IArtisanService
    {
        IDataResult<List<Artisan>> GetAll();
        IResult Add(EsnafDto esnafDto);
        IResult Update(Artisan artisan);
        IResult Delete(Artisan artisan);
        IDataResult<Artisan> GetById(int artisanId);
        IDataResult<List<esnafOrdersDto>> GetOrdersById(int artisanId);
        IDataResult<List<esnafOrdersDto>> GetOrdersDtoForAdmin();
        IDataResult<List<esnafAnswerDto>> GetQuastionsById(int artisanId);
    }
}
