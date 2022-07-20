using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressesDal _addresDal;
        public AddressManager(IAddressesDal addressesDal)
        {
            _addresDal = addressesDal;
        }
        public IResult Add(Address address)
        {
            _addresDal.Add(address);
            return new SuccessResult(Messages.AddressAdded);
        }

        public IResult Delete(int addressId)
        {
            var address = _addresDal.Get(p => p.AddressId == addressId);   
            _addresDal.Delete(address);
            return new SuccessResult(Messages.AddressDeleted);
        }

        public IDataResult<Address> Get(int id)
        {
            return new SuccessDataResult<Address>(_addresDal.Get(o => o.AddressId == id));
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addresDal.GetAll());
        }

        public IDataResult<List<Address>> GetAllByUserId(int id)
        {
            return new SuccessDataResult<List<Address>>(_addresDal.GetAll(p=>p.UserId==id));
        }

        public IResult Update(Address address)
        {
            _addresDal.Update(address);
            return new SuccessResult(Messages.AddressUpdated);
        }
    }
}
