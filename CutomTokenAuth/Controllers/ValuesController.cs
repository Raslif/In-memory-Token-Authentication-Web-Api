using CutomTokenAuth.Filters;
using CutomTokenAuth.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CutomTokenAuth.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ICustomer _customer = null;
        public ValuesController(ICustomer customer)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        [TokenAuthenticationFilter]
        public async Task<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", await _customer.GetName() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
