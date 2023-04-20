using Lomo_Template.Models;
using System.Collections.Generic;

namespace Lomo_Template.Interfaces
{
    public interface ITestService
    {
        List<People> GetPerson();
        People GetPersonById(int id);
        List<Addresses> GetAddresses();
        List<Addresses> GetAddressesWithPeople();
        List<People> GetPeopleWithAddress();
        int CreatePerson(People people);
        int CreateAddresses(Addresses addresses);
    }
}