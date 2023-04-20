using Lomo_Template.Dao;
using Lomo_Template.Interfaces;
using Lomo_Template.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Lomo_Template.Services
{
    public class TestService : BaseServices, ITestService
    {
        private readonly TestDao _dao;
        public TestService(IConfiguration config) : base(config)
        {
            _dao = new TestDao(GetConnectionString());
        }

        #region GET

        public List<People> GetPerson()
        {
            return _dao.GetPerson();
        }
        public People GetPersonById(int id)
        {
            return _dao.GetPersonById(id);
        }
        public List<Addresses> GetAddresses()
        {
            return _dao.GetAddresses();
        }

        public List<Addresses> GetAddressesWithPeople()
        {
            return _dao.GetAddressesWithPeople();
        }

        public List<People> GetPeopleWithAddress()
        {
            return _dao.GetPeopleWithAddress();
        }

        #endregion

        #region POST

        public int CreatePerson(People people)
        {
            return _dao.CreatePerson(people);
        }

        public int CreateAddresses(Addresses address)
        {
            return _dao.CreateAddresses(address);
        }

        #endregion
    }
}
