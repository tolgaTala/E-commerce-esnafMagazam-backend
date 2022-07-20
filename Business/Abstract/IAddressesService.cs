using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IAddressService
    {
        IDataResult<List<Address>> GetAll();
        IDataResult<List<Address>> GetAllByUserId(int id);
        IDataResult<Address> Get(int id);
        IResult Add(Address address);
        IResult Delete(int addressId);
        IResult Update(Address address);
    }
}
