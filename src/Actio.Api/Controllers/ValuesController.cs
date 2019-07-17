using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using RawRabbit.Operations.Publish.Context;
 

namespace Actio.Api.Controllers
{
 

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly BusManager _busMgr;

        private readonly IBusClient _bus;

        // GET api/values
        public  ValuesController(BusManager busMgr  )
        {
            _busMgr = busMgr;
        }

        
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {

 

          _busMgr.SubscribeToCommand<CreateUser>();
             
           _busMgr.PublishToBus<CreateUser>(new CreateUser { Name = "Test..." });


            var task = await Task<IEnumerable<string>>.Run(() => new [] { "value1", "value2"});

            return task;
           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
