using Microsoft.AspNetCore.Mvc;
using QueueManager.Core;

namespace QueueManager.Controllers
{
    [Route("api/mgmt")]
    public class MgmtController : Controller
    {
        private readonly IMgmt _mgmt;
        public MgmtController(IMgmt mgmt)
        {
            _mgmt = mgmt;
        }

        [HttpGet("consumers")]
        public string GetConsumers() {
            var result = _mgmt.GetConsumers();
            return result;
        } 
    }
}