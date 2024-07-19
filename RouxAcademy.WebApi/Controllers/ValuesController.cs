using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace RouxAcademy.WebApi.Controllers
{
    [DisableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IDataProtector _protector;
        private static readonly string[] subPurposes = ["Tenant1"];

        public ValuesController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector(".WebApi.Controllers.ValuesController",
                subPurposes);
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("UserIds")]
        public IEnumerable<string> GetUserIds()
        {
            string sec1 = _protector.Protect("Sadeq");
            string sec2 = _protector.Protect("Ali Rezaei");

            return new string[] { sec1, sec2 };
        }

        [HttpGet]
        [Route("PlainTextId")]
        public string GetPlainTextId(string encryptedId)
        {
            return _protector.Unprotect(encryptedId);
        }
    }
}
