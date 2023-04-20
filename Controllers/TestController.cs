using Lomo_Template.Interfaces;
using Lomo_Template.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lomo_Template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        ITestService _testService;
        public TestController(ITestService testService)
        {
            this._testService = testService;
        }

        #region GET

        [HttpGet]

        public IActionResult GetPerson()
        {
            var res = _testService.GetPerson();
            return Ok(res);
        }

        [HttpGet("getPersonById/{id}")]
        public IActionResult GetPersonById(int id)
        {
            var res = _testService.GetPersonById(id);

            if (res == null)
                NotFound();

            return Ok(res);
        }

        [HttpGet]
        [Route("getAddresses")]
        public IActionResult GetAddresses()
        {
            var res = _testService.GetAddresses();
            return Ok(res);
        }

        [HttpGet]
        [Route("getAddressesWithPeople")]
        public IActionResult GetAddressesWithPeople()
        {
            var res = _testService.GetAddressesWithPeople();
            return Ok(res);
        }

        [HttpGet]
        [Route("getPeopleWithAddress")]
        public IActionResult GetPeopleWithAddress()
        {
            var res = _testService.GetPeopleWithAddress();
            return Ok(res);
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("postPerson")]
        public IActionResult PostPerson([FromBody] People people)
        {
            var res = _testService.CreatePerson(people);
            return Ok(res);
        }

        [HttpPost]
        [Route("postAddress")]
        public IActionResult PostAddress([FromBody] Addresses addresses)
        {
            var res = _testService.CreateAddresses(addresses);
            return Ok(res);
        }

        #endregion
    }
}
